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
    public partial class AdminAllUsersPage : Form
    {
        public AdminAllUsersPage()
        {
            InitializeComponent();
        }

        //This function loads data for the current form
        void LoadData()
        {
            //Clear requestPanel for new controls
            requestPanel.Controls.Clear();

            //Access the connection string from the App.config and open a connection with the database
            Data data = new Data();
            string connectionString = data.ConnectionString;
            List<Tuple<User, string>> userList = new List<Tuple<User, string>>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //Retrieve all the users and their membershipNames to display later and store them into the List of tuples where item1 stores User and item2 stores string for the membership name of that user
                string selectSql = @"SELECT
                                        u.userId, u.username, u.password, u.email, u.bIsAdmin, u.bIsBanned, u.bIsMember, m.membershipTypeId, mt.typeName
                                    FROM 
                                        Users u
                                    LEFT JOIN 
                                        Member m ON u.userId = m.userId
                                    LEFT JOIN 
                                        MembershipType mt ON m.membershipTypeId = mt.membershipTypeId
                                    ORDER BY 
                                        u.username;";

                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User()
                            {
                                userId = Guid.Parse(reader.GetString(reader.GetOrdinal("userId"))),
                                username = reader.GetString(reader.GetOrdinal("username")),
                                password = reader.GetString(reader.GetOrdinal("password")),
                                email = reader.GetString(reader.GetOrdinal("email")),
                                bIsAdmin = reader.GetBoolean(reader.GetOrdinal("bIsAdmin")),
                                bIsBanned = reader.GetBoolean(reader.GetOrdinal("bIsBanned")),
                                bIsMember = reader.GetBoolean(reader.GetOrdinal("bIsMember"))
                            };

                            string membershipName = reader.IsDBNull(reader.GetOrdinal("typeName"))
                                ? ""
                                : reader.GetString(reader.GetOrdinal("typeName"));

                            //Add data to the userList
                            userList.Add(new Tuple<User, string>(user, membershipName));
                        }
                    }
                }

                con.Close();
            }

            if (userList.Count > 0)
            {
                //Loop over the loaded list userList
                int i = 0;
                foreach (var item in userList)
                {
                    //Create a new CC_DisplayUserCard control for each user loaded and asing the values to exposed properties
                    var user = item.Item1;
                    var userDisplayCardControl = new CC_DisplayUserCard();
                    userDisplayCardControl.UserIdLbl = user.userId.ToString();
                    userDisplayCardControl.UsernameText = "Username: " + user.username;
                    userDisplayCardControl.PasswordText = user.password;
                    userDisplayCardControl.EmailText = "Email: " + user.email;
                    userDisplayCardControl.IsAdmin = user.bIsAdmin;
                    userDisplayCardControl.IsBanned = user.bIsBanned;
                    userDisplayCardControl.IsMember = user.bIsMember;

                    if (user.bIsMember)
                    {
                        userDisplayCardControl.MembershipText = "Membership: " + item.Item2;
                        userDisplayCardControl.MembershipTextVisible = true;
                    }
                    else userDisplayCardControl.MembershipTextVisible = false;

                    userDisplayCardControl.ManageButtonClick = (s, eventArg) =>
                    {
                        //On click fo the Manage button take the Admin to the edit that users info
                        AdminEditUserPage adminEditUserPage = new AdminEditUserPage(user);
                        adminEditUserPage.Text = "Admin Edit " + user.username;
                        adminEditUserPage.Owner = this;
                        adminEditUserPage.ShowInTaskbar = false;
                        adminEditUserPage.Show();
                    };

                    //Add the control to the requestPanel
                    requestPanel.Controls.Add(userDisplayCardControl);

                    //Change the location property of the control to make sure they dont overlap
                    if (requestPanel.Controls.Count > 1)
                    {
                        userDisplayCardControl.Location = new Point(0, i * userDisplayCardControl.Size.Height);
                    }
                    else
                    {
                        userDisplayCardControl.Location = new Point(0, 0);
                    }
                    i++;
                }
            }
        }

        //When the Admin refocuses the page it refreshes the data
        private void AdminAllUsersPage_Activated(object sender, EventArgs e)
        {
            //Load the data for the page
            LoadData();
        }
    }
}
