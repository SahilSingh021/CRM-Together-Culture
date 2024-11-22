using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TogetherCultureCRM
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        private void Signup_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            string username = userNameTxt.Text;
            string password = passwordTxt.Text;
            string confirmPassword = confirmPasswordTxt.Text;
            string email = emailTxt.Text;

            #region Sign Up Validations
            if (username == "" || password == "" || confirmPassword == "" || email == "")
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

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords must match. Try again!", "Invalid Password");
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email address. Please enter a valid email address.", "Invalid Email");
                return;
            }
            #endregion

            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Insert row into user table
                string insertUserSql = "INSERT INTO [Users] (username, email, password) VALUES (@username, @email, @password)";
                using (SqlCommand command = new SqlCommand(insertUserSql, con))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);

                    command.ExecuteNonQuery();
                }

                con.Close();

                MessageBox.Show("Registration Successful! You can now sign in.", "Success");

                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }
    }
}
