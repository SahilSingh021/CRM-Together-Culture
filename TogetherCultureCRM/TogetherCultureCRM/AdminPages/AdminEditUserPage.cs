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
using System.Text.RegularExpressions;

namespace TogetherCultureCRM.AdminPages
{
    public partial class AdminEditUserPage : Form
    {
        //A new constructor for when we want to create the page with an user in mind
        public AdminEditUserPage(User selectedUser)
        {
            InitializeComponent();
            _selectdUser = selectedUser;
        }

        public AdminEditUserPage()
        {
            InitializeComponent();
        }

        //This functio executes when the form loads
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Load all the information inside of _selectdUser to the textboxes
            userIdTxt.Text = _selectdUser.userId.ToString();
            usernameTxt.Text = _selectdUser.username;
            emailTxt.Text = _selectdUser.email;
            passwordTxt.Text = _selectdUser.password;
            isAdminCheckBox.Checked = _selectdUser.bIsAdmin;
            isBannedCheckBox.Checked = _selectdUser.bIsBanned;
            isMemberCheckBox.Checked = _selectdUser.bIsMember;
        }

        private User _selectdUser;

        //This function executes when the admin clicks the update button
        private void updateBtn_Click(object sender, EventArgs e)
        {
            //Load all the text inside the textbox fields
            string username = usernameTxt.Text;
            string email = emailTxt.Text;
            string password = passwordTxt.Text;
            bool isAdmin = isAdminCheckBox.Checked;
            bool isBanned = isBannedCheckBox.Checked;
            bool isMember = isMemberCheckBox.Checked;

            //Validate if the text is god data to be inserted into the DB
            #region User Validations
            if (username == "" || password == "" || email == "")
            {
                MessageBox.Show("Please fill in all the feilds.", "Invalid Inputs");
                return;
            }
            if (username.Length < 3 || username.Length > 20 || username.StartsWith("_") || username.EndsWith("_"))
            {
                MessageBox.Show("Please enter a username that is between 3 and 20 characters long. The username cannot start or end with an underscore.", "Invalid Username");
                return;
            }
            if (password.Length < 6 || password.Length > 20)
            {
                MessageBox.Show("Please enter a password that is between 6 and 20 characters long.", "Invalid password");
                return;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email address. Please enter a valid email address.", "Invalid Email");
                return;
            }
            if (username == _selectdUser.username && email == _selectdUser.email && password == _selectdUser.password
                && isAdmin == _selectdUser.bIsAdmin && isBanned == _selectdUser.bIsBanned && isMember == _selectdUser.bIsMember)
            {
                MessageBox.Show("User is already up to date. Nothing to modify.");
                return;
            }
            if (_selectdUser.userId == UserSession.User.userId)
            {
                MessageBox.Show("You cannot update your own user.");
                this.Close();
                return;
            }
            #endregion

            //Access the connection string from the App.config and open a connection with the database
            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //Update the selected user with new details
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
                            //If the selected user is now going to be a admin then add a new record into the admin table
                            Guid adminId = Guid.NewGuid();
                            string insertSql = @"INSERT INTO Admin (adminId, userId) VALUES (@adminId, @userId)";
                            using (SqlCommand command1 = new SqlCommand(insertSql, con))
                            {
                                command1.Parameters.AddWithValue("@adminId", adminId);
                                command1.Parameters.AddWithValue("@userId", _selectdUser.userId);
                                command1.ExecuteNonQuery();
                            }

                            UserSession.User.bIsAdmin = true;
                        }
                        else if (_selectdUser.bIsAdmin && !isAdmin)
                        {
                            //If the selected user is going to be removed from being a admin then remove the existing record from the admin table
                            string deleteSql = @"DELETE FROM Admin WHERE userId=@userId";
                            using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                            {
                                command1.Parameters.AddWithValue("@userId", _selectdUser.userId);
                                command1.ExecuteNonQuery();
                            }
                        }

                        //If the selected user is now going to be a Member
                        if (!_selectdUser.bIsMember && isMember)
                        {
                            //Delete any record of a request in the AdminRequests table to become a member
                            string deleteSql = @"DELETE FROM AdminRequests WHERE userId=@userId";
                            using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                            {
                                command1.Parameters.AddWithValue("@userId", _selectdUser.userId);
                                command1.ExecuteNonQuery();
                            }

                            //Get the ID of the Community membership
                            Guid communityMembershipId;
                            string selectSql = "SELECT membershipTypeId FROM MembershipType WHERE typeName='Community'";
                            using (SqlCommand command1 = new SqlCommand(selectSql, con))
                            {
                                var result = command1.ExecuteScalar();
                                communityMembershipId = Guid.Parse(result.ToString());
                            }

                            //Add a new record into the Member table with the Community membership
                            Guid memberId = Guid.NewGuid();
                            string insertMemberSql = "INSERT INTO Member (memberId, userId, membershipTypeId) VALUES (@memberId, @userId, @membershipTypeId)";
                            using (SqlCommand command1 = new SqlCommand(insertMemberSql, con))
                            {
                                command1.Parameters.AddWithValue("@memberId", memberId);
                                command1.Parameters.AddWithValue("@userId", _selectdUser.userId);
                                command1.Parameters.AddWithValue("@membershipTypeId", communityMembershipId);
                                command1.ExecuteNonQuery();
                            }
                        }
                        else if (_selectdUser.bIsMember && !isMember)
                        {
                            //If the user is no longer going to be a Member
                            //Get the memberId of the selected user
                            Guid memberId = Guid.Empty;
                            string selectSql = "SELECT * FROM Member WHERE userId=@userId";
                            using (SqlCommand command1 = new SqlCommand(selectSql, con))
                            {
                                command1.Parameters.AddWithValue("@userId", _selectdUser.userId);
                                using (SqlDataReader reader = command1.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        memberId = Guid.Parse(reader.GetString(reader.GetOrdinal("memberId")));
                                    }
                                }
                            }

                            //Delete the UsedMemberBenefits of the selected user
                            string deleteSql = @"DELETE FROM UsedMemberBenefits WHERE memberId=@memberId";
                            using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                            {
                                command1.Parameters.AddWithValue("@memberId", memberId);
                                command1.ExecuteNonQuery();
                            }

                            //Delete the Member record of the selected user
                            string deleteSql1 = @"DELETE FROM Member WHERE userId=@userId";
                            using (SqlCommand command1 = new SqlCommand(deleteSql1, con))
                            {
                                command1.Parameters.AddWithValue("@userId", _selectdUser.userId);
                                command1.ExecuteNonQuery();
                            }
                        }

                        //Show success message
                        MessageBox.Show("User updated successfully!");
                    }
                    else
                    {
                        //Show failure message if something went wrong 
                        MessageBox.Show("Update failed. User not found.");
                    }
                }

                con.Close();
            }

            //Update the _selected user with new details (Dont really need too...??)
            _selectdUser.username = username;
            _selectdUser.email = email;
            _selectdUser.password = password;
            _selectdUser.bIsAdmin = isAdmin;
            _selectdUser.bIsBanned = isBanned;
            _selectdUser.bIsMember = isMember;

            //Close form
            this.Close();
        }
    }
}
