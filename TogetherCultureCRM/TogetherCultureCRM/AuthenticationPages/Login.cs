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

        //Function executes when the form is closing and if it is it closes the app as this is a parent form
        private void Login_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        //This function executes when the user clicks the signup button
        private void signUpBtn_Click(object sender, EventArgs e)
        {
            //Show signup form and hide current form
            Signup signup = new Signup();
            this.Hide();
            signup.Show();
        }

        //This function executes when the user clicks the login button
        private void loginBtn_Click(object sender, EventArgs e)
        {
            //Get the text from all the textboxes on the login form and store them in variables
            string username = userNameTxt.Text;
            string password = passwordTxt.Text;

            //Validate the inputs above to see if the user has not made any mistakes
            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill in all the feilds.", "Invalid Inputs");
                return;
            }

            //Access the connection string from the App.config and open a connection with the database
            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //SELECT the User WHERE the username matches with what the user has provided in the username text box
                string selectSql = "SELECT * FROM Users WHERE username=@username";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    //Add the read username text for the placeholder '@username' above
                    command.Parameters.AddWithValue("@username", username);

                    //Execute the SELECT query
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there is a matching user record
                        if (reader.Read())
                        {
                            //If there is a matching record then retrieve the password of that user
                            string storedPassword = reader.GetString(reader.GetOrdinal("password"));

                            //Check to see if the password from the database matches the password the user has provided
                            if (storedPassword == password)
                            {
                                //If password matches - user is authenticated and we load user data into 'User' class instance inside the static 'UserSession' calss
                                UserSession.User.userId = Guid.Parse(reader.GetString(reader.GetOrdinal("userId")));
                                UserSession.User.username = reader.GetString(reader.GetOrdinal("username"));
                                UserSession.User.password = reader.GetString(reader.GetOrdinal("password"));
                                UserSession.User.email = reader.GetString(reader.GetOrdinal("email"));
                                UserSession.User.bIsAdmin = reader.GetBoolean(reader.GetOrdinal("bIsAdmin"));
                                UserSession.User.bIsBanned = reader.GetBoolean(reader.GetOrdinal("bIsBanned"));
                                UserSession.User.bIsMember = reader.GetBoolean(reader.GetOrdinal("bIsMember"));

                                //Check if the user has been banned and if they have then display a message and exit the app
                                if (UserSession.User.bIsBanned)
                                {
                                    MessageBox.Show("You are banned from using this service. Please contact your admin.", "Banned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                //Close this reader so we can execute more to get other user related details
                                reader.Close();

                                //Check if the current user is an admin
                                if (UserSession.User.bIsAdmin)
                                {
                                    //If they are Admin then load the Admin table data into the 'Admin' class instance inside the static 'UserSession' calss
                                    string selectAdminSql = "SELECT * FROM Admin WHERE userId=@userId";
                                    using (SqlCommand command1 = new SqlCommand(selectAdminSql, con))
                                    {
                                        command1.Parameters.AddWithValue("@userId", UserSession.User.userId);
                                        using (SqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            if (reader1.Read())
                                            {
                                                UserSession.Admin.adminId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("adminId")));
                                                UserSession.Admin.userId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("userId")));
                                            }
                                        }
                                    }
                                }

                                //Check if the user is a Member
                                if (UserSession.User.bIsMember)
                                {
                                    //If they are Member then SELECT Member details of the current user from the Member table and store in the 'Member' class instance inside the static 'UserSession' calss
                                    string selectMemberSql = "SELECT * FROM Member WHERE userId=@userId";
                                    using (SqlCommand command1 = new SqlCommand(selectMemberSql, con))
                                    {
                                        command1.Parameters.AddWithValue("@userId", UserSession.User.userId);
                                        using (SqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            if (reader1.Read())
                                            {
                                                UserSession.Member.memberId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("memberId")));
                                                UserSession.Member.userId = UserSession.User.userId;
                                                UserSession.Member.membershipTypeId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("membershipTypeId")));
                                            }
                                        }
                                    }

                                    //Load the Members ActiveMembership details into the 'ActiveMembership' class instance inside the static 'UserSession' calss
                                    string selectActiveMembershipSql = "SELECT * FROM MembershipType WHERE membershipTypeId=@membershipTypeId";
                                    using (SqlCommand command1 = new SqlCommand(selectActiveMembershipSql, con))
                                    {
                                        command1.Parameters.AddWithValue("@membershipTypeId", UserSession.Member.membershipTypeId);
                                        using (SqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            if (reader1.Read())
                                            {
                                                UserSession.ActiveMembership.membershipTypeId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("membershipTypeId")));
                                                UserSession.ActiveMembership.typeName = reader1.GetString(reader1.GetOrdinal("typeName"));
                                                UserSession.ActiveMembership.description = reader1.GetString(reader1.GetOrdinal("description"));
                                                UserSession.ActiveMembership.cost = reader1.GetDecimal(reader1.GetOrdinal("cost"));
                                                UserSession.ActiveMembership.joiningFee = reader1.GetDecimal(reader1.GetOrdinal("joiningFee"));
                                                UserSession.ActiveMembership.duration = reader1.GetString(reader1.GetOrdinal("duration"));
                                            }
                                        }
                                    }

                                    //Load all memberBenefitsIds from the MembershipTypeBenefits table WHERE membershipTypeId matched the current users membershipTypeId
                                    List<Guid> memberBenefitsIdList = new List<Guid>();
                                    string selectSql1 = "SELECT memberBenefitsId FROM MembershipTypeBenefits WHERE membershipTypeId=@membershipTypeId";
                                    using (SqlCommand command1 = new SqlCommand(selectSql1, con))
                                    {
                                        command1.Parameters.AddWithValue("@membershipTypeId", UserSession.Member.membershipTypeId);
                                        using (SqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                memberBenefitsIdList.Add(Guid.Parse(reader1.GetString(reader1.GetOrdinal("memberBenefitsId"))));
                                            }
                                        }
                                    }

                                    //Load all MemberBenefits that are related to each memberBenefitsId inside the memberBenefitsIdList
                                    //Then store them inside the List of 'MemberBenefits' class instances AS 'SubscribedMemberBenefits' inside the static 'UserSession' calss
                                    string selectSql2 = "SELECT * FROM MemberBenefits WHERE memberBenefitsId=@memberBenefitsId";
                                    foreach (Guid memberBenefitsId in memberBenefitsIdList)
                                    {
                                        using (SqlCommand command1 = new SqlCommand(selectSql2, con))
                                        {
                                            command1.Parameters.AddWithValue("@memberBenefitsId", memberBenefitsId);
                                            using (SqlDataReader reader1 = command1.ExecuteReader())
                                            {
                                                while (reader1.Read())
                                                {
                                                    MemberBenefits memberBenefit = new MemberBenefits()
                                                    {
                                                        memberBenefitsId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("memberBenefitsId"))),
                                                        benefitsDescription = reader1.GetString(reader1.GetOrdinal("benefitsDescription"))
                                                    };

                                                    UserSession.SubscribedMemberBenefits.Add(memberBenefit);
                                                }
                                            }
                                        }
                                    }

                                    //Load all UsedMemberBenefits for the current user and store them inside the the List of 'UsedMemberBenefits' class instances AS 'UsedMemberBenefits' inside the static 'UserSession' calss
                                    string selectSql3 = "SELECT * FROM UsedMemberBenefits WHERE memberId=@memberId";
                                    using (SqlCommand command1 = new SqlCommand(selectSql3, con))
                                    {
                                        command1.Parameters.AddWithValue("@memberId", UserSession.Member.memberId);
                                        using (SqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                UsedMemberBenefits usedMemberBenefit = new UsedMemberBenefits()
                                                {
                                                    usedMemberBenefitsId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("usedMemberBenefitsId"))),
                                                    memberId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("memberId"))),
                                                    memberBenefitsId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("memberBenefitsId"))),
                                                    usageDate = reader1.GetDateTime(reader1.GetOrdinal("usageDate"))
                                                };

                                                UserSession.UsedMemberBenefits.Add(usedMemberBenefit);
                                            }
                                        }
                                    }
                                }

                                //Load all events and store them inside the the List of 'Event' class instances AS 'Events' inside the static 'UserSession' calss
                                //And ORDER them by eventDate
                                string selectSql4 = "SELECT * FROM Event ORDER BY eventDate";
                                using (SqlCommand command1 = new SqlCommand(selectSql4, con))
                                {
                                    using (SqlDataReader reader1 = command1.ExecuteReader())
                                    {
                                        while (reader1.Read())
                                        {
                                            Event @event = new Event()
                                            {
                                                eventId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("eventId"))),
                                                tagId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("tagId"))),
                                                eventName = reader1.GetString(reader1.GetOrdinal("eventName")),
                                                eventDate = reader1.GetDateTime(reader1.GetOrdinal("eventDate"))
                                            };

                                            UserSession.Events.Add(@event);
                                        }
                                    }
                                }

                                //Load all visitorLogs for the current user and store them inside the the List of 'VisitorLog' class instances AS 'VisitorLogs' inside the static 'UserSession' calss
                                //And ORDER them by visitDate
                                string selectSql5 = "SELECT * FROM VisitorLog WHERE userId=@userId ORDER BY visitDate";
                                using (SqlCommand command1 = new SqlCommand(selectSql5, con))
                                {
                                    command1.Parameters.AddWithValue("@userId", UserSession.User.userId);
                                    using (SqlDataReader reader1 = command1.ExecuteReader())
                                    {
                                        while (reader1.Read())
                                        {
                                            VisitorLog visitorLog = new VisitorLog()
                                            {
                                                visitorId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("visitorId"))),
                                                userId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("userId"))),
                                                visitDate = reader1.GetDateTime(reader1.GetOrdinal("visitDate")),
                                            };

                                            UserSession.VisitorLogs.Add(visitorLog);
                                        }
                                    }
                                }

                                //Load all DigitalContentModule and store them inside the the List of 'DigitalContentModule' class instances AS 'DigitalContentModules' inside the static 'UserSession' calss
                                string selectSql6 = "SELECT * FROM DigitalContentModule";
                                using (SqlCommand command1 = new SqlCommand(selectSql6, con))
                                {
                                    using (SqlDataReader reader1 = command1.ExecuteReader())
                                    {
                                        while (reader1.Read())
                                        {
                                            DigitalContentModule digitalContentModule = new DigitalContentModule()
                                            {
                                                digitalContentModuleId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("digitalContentModuleId"))),
                                                tagId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("tagId"))),
                                                moduleName = reader1.GetString(reader1.GetOrdinal("moduleName")),
                                            };

                                            UserSession.DigitalContentModules.Add(digitalContentModule);
                                        }
                                    }
                                }

                                //Load all interestTags and store them inside the the List of 'IntrestTag' class instances AS 'IntrestTagList' inside the static 'UserSession' calss
                                string selectSql7 = "SELECT * FROM IntrestTag";
                                using (SqlCommand command1 = new SqlCommand(selectSql7, con))
                                {
                                    using (SqlDataReader reader1 = command1.ExecuteReader())
                                    {
                                        while (reader1.Read())
                                        {
                                            InterestTag intrestTag = new InterestTag()
                                            {
                                                tagId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("tagId"))),
                                                tagName = reader1.GetString(reader1.GetOrdinal("tagName")),
                                            };

                                            UserSession.InterestTagList.Add(intrestTag);
                                        }
                                    }
                                }

                                //Close connection to the DB, show homepage form and hide this form
                                con.Close();
                                Homepage homepage = new Homepage();
                                homepage.Show();
                                this.Hide();
                            }
                            else
                            {
                                //If the password dosnt match show the user a message
                                MessageBox.Show("Wrong credentials! Please try again.", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            //If there is not a matching record then show the user a message
                            MessageBox.Show("Wrong credentials! Please try again.", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
        }
    }
}
