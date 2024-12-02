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
    public partial class AdminManageUsersPage : Form
    {
        public AdminManageUsersPage()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            string searchBarText = searchBarTxt.Text;
            requestPanel.Controls.Clear();
            if (searchBarText.Length <= 0) return;

            Data data = new Data();
            string connectionString = data.ConnectionString;
            List<Tuple<User, string>> userList = new List<Tuple<User, string>>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

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

                            userList.Add(new Tuple<User, string>(user, membershipName));
                        }
                    }
                }

                con.Close();
            }


            if (userList.Count > 0)
            {
                int i = 0;
                foreach (var item in userList)
                {
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
                        AdminEditUserPage adminEditUserPage = new AdminEditUserPage(user);
                        adminEditUserPage.Owner = this;
                        adminEditUserPage.ShowInTaskbar = false;
                        adminEditUserPage.Show();
                    };

                    requestPanel.Controls.Add(userDisplayCardControl);

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

        private void searchBarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoadData();
        }

        private void AdminManageUsersPage_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
