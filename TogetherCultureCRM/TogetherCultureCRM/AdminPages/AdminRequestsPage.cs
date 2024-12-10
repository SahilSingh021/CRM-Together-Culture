using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TogetherCultureCRM.AuthenticationPages;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using TogetherCultureCRM.Classes;
using TogetherCultureCRM.CustomControls;

namespace TogetherCultureCRM.AdminPages
{
    public partial class AdminRequestsPage : Form
    {
        public AdminRequestsPage()
        {
            InitializeComponent();
        }

        private void AdminRequestsPage_Activated(object sender, EventArgs e)
        {
            //Access the connection string from the App.config and open a connection with the database and clear requestPanel for new controls
            requestPanel.Controls.Clear();
            Data data = new Data();
            string connectionString = data.ConnectionString;
            List<Tuple<AdminRequests, string>> adminRequests = new List<Tuple<AdminRequests, string>>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //Select the top 20 records in AdminRequests and their username from the Users table
                string selectSql = "SELECT TOP 20 ar.adminRequestId, ar.userId, ar.requestDescription, ar.requestTime, u.username " +
                    "FROM AdminRequests ar " +
                    "JOIN Users u ON ar.userId = u.userId";

                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AdminRequests adminRequest = new AdminRequests()
                            {
                                adminRequestId = Guid.Parse(reader.GetString(reader.GetOrdinal("adminRequestId"))),
                                userId = Guid.Parse(reader.GetString(reader.GetOrdinal("userId"))),
                                requestDescription = reader.GetString(reader.GetOrdinal("requestDescription")),
                                requestTime = reader.GetDateTime(reader.GetOrdinal("requestTime"))
                            };

                            string username = reader.GetString(reader.GetOrdinal("username"));

                            //Load data into the list tuple we created above
                            adminRequests.Add(new Tuple<AdminRequests, string>(adminRequest, username));
                        }
                    }
                }

                con.Close();
            }

            if (adminRequests.Count > 0)
            {
                //Hide noIncommingRequestsLbl and loop over all adminRequests
                noIncommingRequestsLbl.Hide();
                int i = 0;
                foreach (var item in adminRequests)
                {
                    //Create a new CC_Request control and asign data
                    AdminRequests request = item.Item1;
                    string username = item.Item2;

                    var requestControl = new CC_Request();
                    requestControl.UsernameLbl = username + " - [" + request.requestTime.Date.ToString("dd/MM/yy") + "]";
                    requestControl.DescriptionLbl = request.requestDescription;
                    requestControl.AdminRequestIdLbl = request.adminRequestId.ToString();
                    requestControl.ApproveButtonClick = (s, eventArg) => CC_Request_ApproveBtnClick(request.userId, username);
                    requestControl.DenyButtonClick = (s, eventArg) => CC_Request_DenyBtnClick(request.userId);

                    //Add control to requestPanel
                    requestPanel.Controls.Add(requestControl);

                    //Change the laoction property of each control found so they dont overlap one another
                    if (requestPanel.Controls.Count > 1)
                    {
                        requestControl.Location = new Point(0, i * requestControl.Size.Height);
                    }
                    else
                    {
                        requestControl.Location = new Point(0, 0);
                    }
                    i++;
                }
            }
            else noIncommingRequestsLbl.Show();     //Show noIncommingRequestsLbl
        }

        //This function approves a request and makes the requesting user a member
        public void CC_Request_ApproveBtnClick(Guid userId, string username)
        {
            //Check if the admin is trying to aprove their own request and deny it by showing a message
            if (userId == UserSession.User.userId)
            {
                MessageBox.Show("You cannot approve your own requests.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Access the connection string from the App.config and open a connection with the database
            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //Update the Users table record for this user
                string updateSql = @"UPDATE Users SET bIsMember=1 WHERE userId=@userId";
                using (SqlCommand command = new SqlCommand(updateSql, con))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        //Delete the record from the AdminRequests table as the request has been processed
                        string deleteSql = @"DELETE FROM AdminRequests WHERE userId=@userId";
                        using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                        {
                            command1.Parameters.AddWithValue("@userId", userId);
                            command1.ExecuteNonQuery();
                        }

                        //Get the Id of the Community membership
                        Guid communityMembershipId;
                        string selectSql = "SELECT membershipTypeId FROM MembershipType WHERE typeName = 'Community'";
                        using (SqlCommand command1 = new SqlCommand(selectSql, con))
                        {
                            var result = command1.ExecuteScalar();
                            communityMembershipId = Guid.Parse(result.ToString());
                        }

                        //Add a new record into Member table for this user with the Community membership
                        Guid memberId = Guid.NewGuid();
                        string insertMemberSql = "INSERT INTO Member (memberId, userId, membershipTypeId) VALUES (@memberId, @userId, @membershipTypeId)";
                        using (SqlCommand command1 = new SqlCommand(insertMemberSql, con))
                        {
                            command1.Parameters.AddWithValue("@memberId", memberId);
                            command1.Parameters.AddWithValue("@userId", userId);
                            command1.Parameters.AddWithValue("@membershipTypeId", communityMembershipId);
                            command1.ExecuteNonQuery();
                        }
                    }
                }

                //Show success message
                MessageBox.Show(username + " now is a community member.");
            }
        }

        //This function denies a request and makes the requesting user a member
        public void CC_Request_DenyBtnClick(Guid userId)
        {
            //Access the connection string from the App.config and open a connection with the database
            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                //Delete the record from the AdminRequests table as the request has been processed
                string deleteSql = @"DELETE FROM AdminRequests WHERE userId=@userId";
                using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                {
                    command1.Parameters.AddWithValue("@userId", userId);
                    command1.ExecuteNonQuery();
                }
            }

            //Success message
            MessageBox.Show("User request has been denied.");
        }
    }
}
