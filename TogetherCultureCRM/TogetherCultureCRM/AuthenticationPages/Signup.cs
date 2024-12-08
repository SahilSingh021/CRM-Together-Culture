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

namespace TogetherCultureCRM.AuthenticationPages
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        //Function executes when the form is closing and if it is it closes the app as this is a parent form
        private void Signup_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        //This function executes when the user clicks the login button
        private void loginBtn_Click(object sender, EventArgs e)
        {
            // Show the Login form and hide the current form
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        //This function executes when the user clicks the signup button
        private void signUpBtn_Click(object sender, EventArgs e)
        {
            //Get the text from all the textboxes on the signup page and store them in variables
            string username = userNameTxt.Text;
            string password = passwordTxt.Text;
            string confirmPassword = confirmPasswordTxt.Text;
            string email = emailTxt.Text;

            //Validate the inputs above to see if the user has not made any mistakes
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

            //Access the connection string from the App.config and open a connection with the database
            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //Make a new userId and INSERT a new user record into the Users table using the details the user has provided
                Guid userId = Guid.NewGuid();
                string insertUserSql = "INSERT INTO [Users] (userId, username, email, password) VALUES (@userId, @username, @email, @password)";
                using (SqlCommand command = new SqlCommand(insertUserSql, con))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);

                    command.ExecuteNonQuery();
                }

                //Display Success Message to the user
                MessageBox.Show("Registration Successful! You can now sign in.", "Success");

                //Show the Login form so the user can signin
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }
    }
}
