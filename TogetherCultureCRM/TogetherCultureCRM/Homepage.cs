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
using TogetherCultureCRM.CustomControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TogetherCultureCRM
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void AdminHomePage_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        private Button _adminHomePageTabBtn;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            loggedInLbl.Text = UserSession.User.username;

            homePagePanel.BringToFront();
            homeDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            Homepage.ActiveForm.Text = "Home Page";

            if (UserSession.User.bIsAdmin)
            {
                _adminHomePageTabBtn = new Button
                {
                    BackColor = Color.FromArgb(247, 255, 247),
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    ForeColor = Color.Black,
                    Location = new Point(0, 477),
                    Name = "adminHomePageTabBtn",
                    Size = new Size(200, 43),
                    TabIndex = 11,
                    Text = "     Admin Page",
                    TextAlign = ContentAlignment.MiddleLeft,
                    UseVisualStyleBackColor = false
                };

                _adminHomePageTabBtn.FlatAppearance.BorderColor = Color.Silver;
                _adminHomePageTabBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
                _adminHomePageTabBtn.Click += new EventHandler(adminHomePageTabBtn_Click);

                this.dashboard.Controls.Add(_adminHomePageTabBtn);
            }
        }

        public void DashboardBtn_BackColorReset()
        {
            Color col = Color.FromArgb(247, 255, 247);
            homeDashboardBtn.BackColor = col;
            profileDashboardBtn.BackColor = col;
            membershipPageTabBtn.BackColor = col;
            benefitsDashboardBtn.BackColor = col;
            eventsHomePageTabBtn.BackColor = col;
            placeHireDashboardBtn.BackColor = col;
            digitalConnectionDashboardBtn.BackColor = col;
            onlineMembersAreadDashboardBtn.BackColor = col;

            if (UserSession.User.bIsAdmin && _adminHomePageTabBtn != null)
            {
                _adminHomePageTabBtn.BackColor = col;
            }
        }

        private void manageRequestsBtn_Click(object sender, EventArgs e)
        {
            AdminRequestsPage adminRequestsPage = new AdminRequestsPage();
            adminRequestsPage.Owner = this;
            adminRequestsPage.ShowInTaskbar = false;
            adminRequestsPage.Show();
        }

        private void manageUserBtn_Click(object sender, EventArgs e)
        {
            AdminManageUsersPage adminManageUsersPage = new AdminManageUsersPage();
            adminManageUsersPage.Owner = this;
            adminManageUsersPage.ShowInTaskbar = false;
            adminManageUsersPage.Show();
        }

        private void adminHomePageTabBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            _adminHomePageTabBtn.BackColor = Color.FromArgb(128, 255, 128);
            adminHomePagePanel.BringToFront();
            Homepage.ActiveForm.Text = "Admin Home Page";
        }

        public void BookEvent(Guid eventId, Guid tagId)
        {
            bool bEventAlreadyBooked = false;
            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //check if user has already booked this event
                string selectSql = "SELECT * FROM UserEvents WHERE userId=@userId AND eventId=@eventId";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                    command.Parameters.AddWithValue("@eventId", eventId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bEventAlreadyBooked = true;
                        }
                    }
                }

                if (bEventAlreadyBooked)
                {
                    con.Close();
                    MessageBox.Show("You have already booked this event!", "Event Booked");
                    return;
                }

                //insert record into UserEvents
                string insertSql = "INSERT INTO UserEvents (eventId, userId) VALUES (@eventId, @userId)";
                using (SqlCommand command = new SqlCommand(insertSql, con))
                {
                    command.Parameters.AddWithValue("@eventId", eventId);
                    command.Parameters.AddWithValue("@userId", UserSession.User.userId);

                    command.ExecuteNonQuery();
                }

                //insert record into UserTag
                string insertSql1 = "INSERT INTO UserTag (userId, tagId) VALUES (@userId, @tagId)";
                using (SqlCommand command = new SqlCommand(insertSql1, con))
                {
                    command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                    command.Parameters.AddWithValue("@tagId", tagId);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("You have booked this Event!", "Event Booked");
        }

        private void eventsHomePageTabBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            eventsHomePageTabBtn.BackColor = Color.FromArgb(128, 255, 128);
            eventsHomePageTabPanel.BringToFront();
            Homepage.ActiveForm.Text = "Events Home Page";

            int heightCount = 0;
            int widthCount = 0;
            foreach (var Event in UserSession.Events)
            {
                var eventDisplayCard = new CC_DisplayEventCard()
                {
                    EventId = Event.eventId.ToString(),
                    TagId = Event.tagId.ToString(),
                    EventName = Event.eventName,
                    EventDate = Event.eventDate.ToString("dddd-mm-yyyy"),
                    EventTime = Event.eventDate.ToString("t"),
                    BookEventClick = (s, eventArg) =>
                    {
                        BookEvent(Guid.Parse(Event.eventId.ToString()), Guid.Parse(Event.tagId.ToString()));
                    }
                };

                eventBookingPanel.Controls.Add(eventDisplayCard);
                if (eventBookingPanel.Controls.Count > 0)
                {
                    eventDisplayCard.Location = new Point(widthCount * eventDisplayCard.Size.Width, heightCount * eventDisplayCard.Size.Height);
                    if (widthCount > 3)
                    {
                        heightCount++;
                        widthCount = 0;
                    }
                }
                else
                {
                    eventDisplayCard.Location = new Point(0, 0);
                }
                
                widthCount++;
            }
        }

        private void membershipPageTabBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            membershipPageTabBtn.BackColor = Color.FromArgb(128, 255, 128);

            if (UserSession.User.bIsMember)
            {
                var selectedMembership = UserSession.ActiveMembership;

                membershipNameLbl.Text = "Membership Name: " + selectedMembership.typeName;
                descriptionLbl.Text = "Description: " + selectedMembership.description;
                costLbl.Text = "Cost: £" + selectedMembership.cost.ToString();
                joiningFeeLbl.Text = "Joining Fee: £" + selectedMembership.joiningFee.ToString();
                durationLbl.Text = "Duration: " + selectedMembership.duration;

                activeMembershipPanel.BringToFront();
            }
            else
            {
                membershipDropBox.Items.Clear();
                UserSession.MembershipTypes.Clear();
                Data data = new Data();
                string connectionString = data.ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string selectMembershipTypeSql = "SELECT * FROM MembershipType";
                    using (SqlCommand command1 = new SqlCommand(selectMembershipTypeSql, con))
                    {
                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                MembershipType membershipType = new MembershipType()
                                {
                                    membershipTypeId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("membershipTypeId"))),
                                    typeName = reader1.GetString(reader1.GetOrdinal("typeName")),
                                    description = reader1.GetString(reader1.GetOrdinal("description")),
                                    cost = reader1.GetDecimal(reader1.GetOrdinal("cost")),
                                    joiningFee = reader1.GetDecimal(reader1.GetOrdinal("joiningFee")),
                                    duration = reader1.GetString(reader1.GetOrdinal("duration"))
                                };

                                UserSession.MembershipTypes.Add(membershipType);
                            }
                        }
                    }
                }

                foreach (var membershipType in UserSession.MembershipTypes)
                {
                    membershipDropBox.Items.Add(membershipType.typeName);
                }

                membershipPanel.BringToFront();
            }

            Homepage.ActiveForm.Text = "Membership Page";
        }

        private void homeDashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            homeDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            homePagePanel.BringToFront();
            Homepage.ActiveForm.Text = "Home Page";
        }

        private void profileDashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            profileDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            profilePagePanel.BringToFront();
            Homepage.ActiveForm.Text = "Profile Page";

            if (!UserSession.User.bIsMember)
            {
                // Check if the user has already made a request to become a member
                bool bRequestMade = false;
                DateTime requestDateTime = DateTime.Now;
                Data dataCls = new Data();
                string connectionString = dataCls.ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string selectSql = "SELECT * FROM AdminRequests WHERE userId=@userId";
                    using (SqlCommand command = new SqlCommand(selectSql, con))
                    {
                        command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                requestDateTime = reader.GetDateTime(reader.GetOrdinal("requestTime"));
                                bRequestMade = true;
                            }
                        }
                    }
                    con.Close();
                }

                if (!bRequestMade)
                {
                    postRequestPanel.Hide();
                    preMemberPanel.Show();
                    preMemberPanel.BringToFront();
                }
                else
                {
                    requestDateLbl.Text = "Request Date: " + requestDateTime.ToString("dd/MMMM/yyyyy");
                    preMemberPanel.Hide();
                    postRequestPanel.Show();
                    postRequestPanel.BringToFront();
                }
            }
        }

        private void benefitsDashboardBtn_Click(object sender, EventArgs e)
        {
            if (!UserSession.User.bIsMember)
            {
                DialogResult result = MessageBox.Show(
                    "This is a members-only area. Would you like to view available memberships?",
                    "Membership Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes) membershipPageTabBtn.PerformClick();
                return;
            }

            DashboardBtn_BackColorReset();
            benefitsDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            benefitsPagePanel.BringToFront();
            Homepage.ActiveForm.Text = "Active Benefits Page";

            StringBuilder usedBenefitsSB = new StringBuilder();
            StringBuilder unusedBenefitsSB = new StringBuilder();
            foreach (MemberBenefits memberBenefit in UserSession.SubscribedMemberBenefits)
            {
                bool usedBenefit = false;
                foreach (UsedMemberBenefits usedMemberBenefit in UserSession.UsedMemberBenefits)
                {
                    if (memberBenefit.memberBenefitsId == usedMemberBenefit.memberBenefitsId)
                    {
                        usedBenefitsSB.AppendLine(memberBenefit.benefitsDescription);
                        usedBenefit = true;
                    }
                }
                if (!usedBenefit) unusedBenefitsSB.AppendLine(memberBenefit.benefitsDescription);
            }

            unusedBenefitsTxtBox.Text = unusedBenefitsSB.ToString();
            if (UserSession.UsedMemberBenefits.Count > 0) usedBenefitsTxtBox.Text = usedBenefitsSB.ToString();
            else usedBenefitsTxtBox.Text = "No benefits have been used so far.";
        }

        private void placeHireDashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            placeHireDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            placeHirePanel.BringToFront();
            Homepage.ActiveForm.Text = "Place Hire Page";
        }

        private void digitalConnectionDashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            digitalConnectionDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            digitalConnectionPanel.BringToFront();
            Homepage.ActiveForm.Text = "Digital Connection Page";
        }

        private void onlineMembersAreadDashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            onlineMembersAreadDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            onlineMembersAreaPanel.BringToFront();
            Homepage.ActiveForm.Text = "Online Members Area Page";
        }

        private void membershipDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMembershipTypeName = membershipDropBox.Text;
            var selectedMembership = UserSession.MembershipTypes.FirstOrDefault(mt => mt.typeName == selectedMembershipTypeName);

            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;
            List<string> memberBenefits = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<Guid> memberBenefitsIdList = new List<Guid>();
                con.Open();
                string selectSql = "SELECT memberBenefitsId FROM MembershipTypeBenefits WHERE membershipTypeId=@membershipTypeId";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@membershipTypeId", selectedMembership.membershipTypeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            memberBenefitsIdList.Add(Guid.Parse(reader.GetString(reader.GetOrdinal("memberBenefitsId"))));
                        }
                    }
                }

                string selectSql1 = "SELECT benefitsDescription FROM MemberBenefits WHERE memberBenefitsId=@memberBenefitsId";
                foreach (Guid memberBenefitsId in memberBenefitsIdList)
                {
                    using (SqlCommand command1 = new SqlCommand(selectSql1, con))
                    {
                        command1.Parameters.AddWithValue("@memberBenefitsId", memberBenefitsId);
                        using (SqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                memberBenefits.Add(reader.GetString(reader.GetOrdinal("benefitsDescription")));
                            }
                        }
                    }
                }
            }

            membershipDescriptionTxtBox.Text = "Membership Name: " + selectedMembership.typeName + "\nDescription: " + selectedMembership.description + "\nCost: £" +
            selectedMembership.cost.ToString() + "\nJoining Fee: £" + selectedMembership.joiningFee.ToString() + "\nDuration: " + selectedMembership.duration;

            StringBuilder sb = new StringBuilder();
            foreach (string memberBenefit in memberBenefits)
            {
                sb.AppendLine(memberBenefit);
            }

            membershipBenefitsTxtBox.Text = sb.ToString();
        }

        private void becomeAMemberBtn_Click(object sender, EventArgs e)
        {
            Guid memberId = Guid.NewGuid();
            Guid currentUserId = UserSession.User.userId;
            string selectedMembershipTypeName = membershipDropBox.Text;
            var selectedMembership = UserSession.MembershipTypes.FirstOrDefault(mt => mt.typeName == selectedMembershipTypeName);

            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Delete any requests in the AdminRequests table created at signup
                string deleteSql = @"DELETE FROM AdminRequests WHERE userId=@userId";
                using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                {
                    command1.Parameters.AddWithValue("@userId", currentUserId);
                    command1.ExecuteNonQuery();
                }

                // Update Users table for bIsMemeber
                string updateUserSql = "UPDATE Users SET bIsMember=1 WHERE userId=@userId";
                using (SqlCommand command = new SqlCommand(updateUserSql, con))
                {
                    command.Parameters.AddWithValue("@userId", currentUserId);
                    command.ExecuteNonQuery();
                }

                // Add record to Member table
                string insertMemberSql = "INSERT INTO Member (memberId, userId, membershipTypeId) VALUES (@memberId, @userId, @membershipTypeId)";
                using (SqlCommand command = new SqlCommand(insertMemberSql, con))
                {
                    command.Parameters.AddWithValue("@memberId", memberId);
                    command.Parameters.AddWithValue("@userId", currentUserId);
                    command.Parameters.AddWithValue("@membershipTypeId", selectedMembership.membershipTypeId);
                    command.ExecuteNonQuery();
                }

                // Load Active Member Benefits
                List<Guid> memberBenefitsIdList = new List<Guid>();
                string selectSql1 = "SELECT memberBenefitsId FROM MembershipTypeBenefits WHERE membershipTypeId=@membershipTypeId";
                using (SqlCommand command1 = new SqlCommand(selectSql1, con))
                {
                    command1.Parameters.AddWithValue("@membershipTypeId", selectedMembership.membershipTypeId);
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
                con.Close();

                UserSession.User.bIsMember = true;

                UserSession.Member.memberId = memberId;
                UserSession.Member.userId = currentUserId;
                UserSession.Member.membershipTypeId = selectedMembership.membershipTypeId;

                UserSession.ActiveMembership = selectedMembership;

                UserSession.MembershipTypes.Clear();

                MessageBox.Show("You membership has been updated to " + selectedMembership.typeName + "!");
            }

            membershipPageTabBtn.PerformClick();
        }

        private void cancleMembershipBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to cancel your memberships?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

            if (result == DialogResult.Yes)
            {
                Guid currentUserId = UserSession.User.userId;
                Data dataCls = new Data();
                string connectionString = dataCls.ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Update Users table for bIsMemeber
                    string updateUserSql = "UPDATE Users SET bIsMember=0 WHERE userId=@userId";
                    using (SqlCommand command = new SqlCommand(updateUserSql, con))
                    {
                        command.Parameters.AddWithValue("@userId", currentUserId);
                        command.ExecuteNonQuery();
                    }

                    // Delete UsedMemberBenefits records as member table has a FK restraint based of this table
                    string deleteSql1 = @"DELETE FROM UsedMemberBenefits WHERE memberId=@memberId";
                    using (SqlCommand command1 = new SqlCommand(deleteSql1, con))
                    {
                        command1.Parameters.AddWithValue("@memberId", UserSession.Member.memberId);
                        command1.ExecuteNonQuery();
                    }

                    // Delete Member record
                    string deleteSql = @"DELETE FROM Member WHERE userId=@userId";
                    using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                    {
                        command1.Parameters.AddWithValue("@userId", currentUserId);
                        command1.ExecuteNonQuery();
                    }
                }

                UserSession.User.bIsMember = false;
                UserSession.Member = new Member();
                UserSession.ActiveMembership = new MembershipType();
                UserSession.SubscribedMemberBenefits.Clear();
                UserSession.UsedMemberBenefits.Clear();

                membershipPageTabBtn.PerformClick();
            }
            return;
        }

        private void requestMembershipBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to submit a membership request?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                Data dataCls = new Data();
                string connectionString = dataCls.ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    Guid adminRequestId = Guid.NewGuid();
                    string insertRequestSql = "INSERT INTO [AdminRequests] (adminRequestId, userId, requestDescription, requestTime) VALUES (@adminRequestId, @userId, @requestDescription, @requestTime)";
                    using (SqlCommand command = new SqlCommand(insertRequestSql, con))
                    {
                        command.Parameters.AddWithValue("@adminRequestId", adminRequestId);
                        command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                        command.Parameters.AddWithValue("@requestDescription", "Request to become a member.");
                        command.Parameters.AddWithValue("@requestTime", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }

                profileDashboardBtn.PerformClick();
            }
            return;
        }

    }
}
