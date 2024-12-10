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
    public partial class AdminUserEventSearchPage : Form
    {
        public AdminUserEventSearchPage()
        {
            InitializeComponent();
        }

        //This function loads data for the current form
        void LoadData()
        {
            //Get the text from the search bar and clear requestPanel for new controls
            string searchBarText = searchBarTxt.Text;
            requestPanel.Controls.Clear();
            if (searchBarText.Length <= 0) return;

            //Access the connection string from the App.config and open a connection with the database
            Data data = new Data();
            string connectionString = data.ConnectionString;
            List<Tuple<User, string>> userList = new List<Tuple<User, string>>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //Select the top 20 records of users and membershipName, where username matches with the serachbar text from the user and order by username
                string selectSql = @"SELECT TOP 20
                                        u.userId, u.username, u.password, u.email, u.bIsAdmin, u.bIsBanned, u.bIsMember, m.membershipTypeId, mt.typeName
                                    FROM 
                                        Users u
                                    LEFT JOIN 
                                        Member m ON u.userId = m.userId
                                    LEFT JOIN 
                                        MembershipType mt ON m.membershipTypeId = mt.membershipTypeId
                                    WHERE 
                                        LOWER(u.username) LIKE LOWER(@searchText) + '%'
                                    ORDER BY 
                                        u.username;";

                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@searchText", searchBarText);

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

                            //Load data into userList
                            userList.Add(new Tuple<User, string>(user, membershipName));
                        }
                    }
                }

                con.Close();
            }


            if (userList.Count > 0)
            {
                //Loop over all userList
                int i = 0;
                foreach (var item in userList)
                {
                    //Create a new CC_DisplayUserCard control and asign data
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

                    userDisplayCardControl.ManageButtonText = "View Event && Vist Details";
                    userDisplayCardControl.ManageButtonClick = (s, eventArg) =>
                    {
                        //Create a new AdminViewUserEventsAndVisitsPage and pass the event to the custom constructor we created
                        //Change some page properties and show the newley created page
                        AdminViewUserEventsAndVisitsPage adminViewUserEventsAndVisitsPage = new AdminViewUserEventsAndVisitsPage(user);
                        adminViewUserEventsAndVisitsPage.Text = user.username + "'s Events & Visit Logs";
                        adminViewUserEventsAndVisitsPage.Owner = this;
                        adminViewUserEventsAndVisitsPage.ShowInTaskbar = false;
                        adminViewUserEventsAndVisitsPage.Show();
                    };

                    //Add control to requestPanel
                    requestPanel.Controls.Add(userDisplayCardControl);

                    //Change the laoction property of each control found so they dont overlap one another
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

        //This function executed when user click a key while focused on the searchbar control
        private void searchBarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Load the data for the page
            LoadData();
        }

        //This function executed when user refocuses on the form
        private void AdminUserEventSearchPage_Activated(object sender, EventArgs e)
        {
            //Load the data for the page
            LoadData();
        }
    }
}
