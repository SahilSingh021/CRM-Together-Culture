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
            requestPanel.Controls.Clear();

            Data data = new Data();
            string connectionString = data.ConnectionString;
            List<Tuple<AdminRequests, string>> adminRequests = new List<Tuple<AdminRequests, string>>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

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
                            adminRequests.Add(new Tuple<AdminRequests, string>(adminRequest, username));
                        }
                    }
                }

                con.Close();
            }

            if (adminRequests.Count > 0)
            {
                noIncommingRequestsLbl.Hide();
                int i = 0;
                foreach (var item in adminRequests)
                {
                    AdminRequests request = item.Item1;
                    string username = item.Item2;

                    var requestControl = new CC_Request();
                    requestControl.UsernameLbl = username + " - [" + request.requestTime.Date.ToString("dd/MM/yy") + "]";
                    requestControl.DescriptionLbl = request.requestDescription;
                    requestControl.AdminRequestIdLbl = request.adminRequestId.ToString();
                    requestControl.ApproveButtonClick = (s, eventArg) => CC_Request_ApproveBtnClick(request.userId, username);
                    requestControl.DenyButtonClick = (s, eventArg) => CC_Request_DenyBtnClick(request.userId);

                    requestPanel.Controls.Add(requestControl);

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
            else noIncommingRequestsLbl.Show();
        }

        public void CC_Request_ApproveBtnClick(Guid userId, string username)
        {
            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string updateSql = @"UPDATE Users SET bIsMember=1 WHERE userId=@userId";
                using (SqlCommand command = new SqlCommand(updateSql, con))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        string deleteSql = @"DELETE FROM AdminRequests WHERE userId=@userId";
                        using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                        {
                            command1.Parameters.AddWithValue("@userId", userId);
                            command1.ExecuteNonQuery();
                        }

                        Guid communityMembershipId;
                        string selectSql = "SELECT membershipTypeId FROM MembershipType WHERE typeName = 'Community'";
                        using (SqlCommand command1 = new SqlCommand(selectSql, con))
                        {
                            var result = command1.ExecuteScalar();
                            communityMembershipId = Guid.Parse(result.ToString());
                        }

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

                MessageBox.Show(username + " now is a community member.");
            }
        }

        public void CC_Request_DenyBtnClick(Guid userId)
        {
            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string deleteSql = @"DELETE FROM AdminRequests WHERE userId=@userId";
                using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                {
                    command1.Parameters.AddWithValue("@userId", userId);
                    command1.ExecuteNonQuery();
                }
            }

            MessageBox.Show("User request has been denied.");
        }
    }
}
