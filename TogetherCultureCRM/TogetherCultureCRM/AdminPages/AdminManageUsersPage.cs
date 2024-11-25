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

        private void searchBarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            string searchBarText = searchBarTxt.Text;

            if (searchBarText.Length <= 0)
            {
                requestPanel.Controls.Clear();
                return;
            }

            requestPanel.Controls.Clear();
            Data data = new Data();
            string connectionString = data.ConnectionString;
            List<User> userList = new List<User>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectSql = "SELECT TOP 20 * FROM Users WHERE LOWER(username) LIKE LOWER(@searchText) + '%'";
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
                                bIsBanned = reader.GetBoolean(reader.GetOrdinal("bIsBanned"))
                            };

                            userList.Add(user);
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
                    var userDisplayCardControl = new CC_DisplayUserCard();
                    userDisplayCardControl.UserIdLbl = item.userId.ToString();
                    userDisplayCardControl.UsernameText = item.username;
                    userDisplayCardControl.PasswordText = item.password;
                    userDisplayCardControl.EmailText = item.email;
                    userDisplayCardControl.IsAdmin = item.bIsAdmin;
                    userDisplayCardControl.IsBanned = item.bIsBanned;
                    userDisplayCardControl.ManageButtonClick = (s, eventArg) =>
                    {
                        AdminEditUserPage adminEditUserPage = new AdminEditUserPage(item);
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
    }
}
