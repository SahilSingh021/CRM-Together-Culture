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
using TogetherCultureCRM.AdminPages;
using TogetherCultureCRM.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TogetherCultureCRM.AuthenticationPages
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = userNameTxt.Text;
            string password = passwordTxt.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill in all the feilds.", "Invalid Inputs");
                return;
            }

            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectSql = "SELECT * FROM [Users] WHERE username=@username";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there is a matching user record
                        if (reader.Read())
                        {
                            string storedPassword = reader.GetString(reader.GetOrdinal("password"));

                            if (storedPassword == password)
                            {
                                // Passwords match - user is authenticated
                                UserSession.userId = Guid.Parse(reader.GetString(reader.GetOrdinal("userId")));
                                UserSession.username = reader.GetString(reader.GetOrdinal("username"));
                                UserSession.password = reader.GetString(reader.GetOrdinal("password"));
                                UserSession.email = reader.GetString(reader.GetOrdinal("email"));
                                UserSession.bIsAdmin = reader.GetBoolean(reader.GetOrdinal("bIsAdmin"));
                                UserSession.bIsBanned = reader.GetBoolean(reader.GetOrdinal("bIsBanned"));

                                if (UserSession.bIsBanned)
                                {
                                    MessageBox.Show("You are banned from using this service. Please contact your admin.", "Banned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                reader.Close();

                                if (UserSession.bIsAdmin)
                                {
                                    string selectAdminSql = "SELECT * FROM [Admin] WHERE userId=@userId";
                                    using (SqlCommand command1 = new SqlCommand(selectAdminSql, con))
                                    {
                                        command1.Parameters.AddWithValue("@userId", UserSession.userId);
                                        using (SqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            if (reader1.Read())
                                            {
                                                Admin.adminId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("adminId")));
                                                Admin.userId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("userId")));
                                            }
                                        }
                                    }
                                }

                                if (UserSession.bIsAdmin)
                                {
                                    AdminHomePage adminHomePage = new AdminHomePage();
                                    adminHomePage.Show();
                                }
                                else
                                {
                                    Homepage homepage = new Homepage();
                                    homepage.Show();
                                }

                                this.Hide();
                            }
                            else
                            {
                                // Passwords do not match - authentication failed
                                MessageBox.Show("Authentication Unsuccessful. Please Try Again!", "Failure");
                            }
                        }
                        else
                        {
                            // No matching user record - authentication failed
                            MessageBox.Show("Authentication Unsuccessful. Please Try Again!", "Failure");
                        }
                    }
                }

                con.Close();
            }
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            this.Hide();
            signup.Show();
        }
    }
}
