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

                string selectSql = "SELECT * FROM Users WHERE username=@username";
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
                                UserSession.User.userId = Guid.Parse(reader.GetString(reader.GetOrdinal("userId")));
                                UserSession.User.username = reader.GetString(reader.GetOrdinal("username"));
                                UserSession.User.password = reader.GetString(reader.GetOrdinal("password"));
                                UserSession.User.email = reader.GetString(reader.GetOrdinal("email"));
                                UserSession.User.bIsAdmin = reader.GetBoolean(reader.GetOrdinal("bIsAdmin"));
                                UserSession.User.bIsBanned = reader.GetBoolean(reader.GetOrdinal("bIsBanned"));
                                UserSession.User.bIsMember = reader.GetBoolean(reader.GetOrdinal("bIsMember"));


                                if (UserSession.User.bIsBanned)
                                {
                                    MessageBox.Show("You are banned from using this service. Please contact your admin.", "Banned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                reader.Close();

                                if (UserSession.User.bIsAdmin)
                                {
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

                                if (UserSession.User.bIsMember)
                                {
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

                                con.Close();
                                Homepage homepage = new Homepage();
                                homepage.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Wrong credentials! Please try again.", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Wrong credentials! Please try again.", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
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
