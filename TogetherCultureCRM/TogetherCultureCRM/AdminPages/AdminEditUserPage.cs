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
    public partial class AdminEditUserPage : Form
    {
        public AdminEditUserPage(User selectedUser)
        {
            InitializeComponent();
            _selectdUser = selectedUser;
        }

        public AdminEditUserPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            userIdTxt.Text = _selectdUser.userId.ToString();
            usernameTxt.Text = _selectdUser.username;
            emailTxt.Text = _selectdUser.email;
            passwordTxt.Text = _selectdUser.password;
            isAdminCheckBox.Checked = _selectdUser.bIsAdmin;
            isBannedCheckBox.Checked = _selectdUser.bIsBanned;
            isMemberCheckBox.Checked = _selectdUser.bIsMember;
        }

        private User _selectdUser;

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string email = emailTxt.Text;
            string password = passwordTxt.Text;
            bool isAdmin = isAdminCheckBox.Checked;
            bool isBanned = isBannedCheckBox.Checked;
            bool isMember = isMemberCheckBox.Checked;

            if (username == _selectdUser.username && email == _selectdUser.email && password == _selectdUser.password
                && isAdmin == _selectdUser.bIsAdmin && isBanned == _selectdUser.bIsBanned && isMember == _selectdUser.bIsMember)
            {
                MessageBox.Show("User is already up to date. Nothing to modify.");
                return;
            }

            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string updateSql = @"UPDATE Users SET username = @username, 
                                                      email = @email, 
                                                      password = @password, 
                                                      bIsAdmin = @isAdmin, 
                                                      bIsBanned = @isBanned,
                                                      bIsMember = @isMember WHERE userId = @userId";
                                                      

                using (SqlCommand command = new SqlCommand(updateSql, con))
                {
                    command.Parameters.AddWithValue("@userId", _selectdUser.userId);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@isAdmin", isAdmin);
                    command.Parameters.AddWithValue("@isBanned", isBanned);
                    command.Parameters.AddWithValue("@isMember", isMember);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        if (!_selectdUser.bIsAdmin && isAdmin)
                        {
                            Guid adminId = Guid.NewGuid();
                            string insertSql = @"INSERT INTO Admin (adminId, userId) VALUES (@adminId, @userId)";
                            using (SqlCommand command1 = new SqlCommand(insertSql, con))
                            {
                                command1.Parameters.AddWithValue("@adminId", adminId);
                                command1.Parameters.AddWithValue("@userId", _selectdUser.userId);
                                command1.ExecuteNonQuery();
                            }
                        }
                        else if (_selectdUser.bIsAdmin && !isAdmin)
                        {
                            string deleteSql = @"DELETE FROM Admin WHERE userId = @userId";
                            using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                            {
                                command1.Parameters.AddWithValue("@userId", _selectdUser.userId);
                                command1.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("User updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. User not found.");
                    }
                }

                con.Close();
            }

            _selectdUser.username = username;
            _selectdUser.email = email;
            _selectdUser.password = password;
            _selectdUser.bIsAdmin = isAdmin;
            _selectdUser.bIsBanned = isBanned;
            _selectdUser.bIsMember = isMember;

            this.Close();
        }
    }
}
