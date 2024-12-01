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
            adminRequestsPage.Show();
        }

        private void manageUserBtn_Click(object sender, EventArgs e)
        {
            AdminManageUsersPage adminManageUsersPage = new AdminManageUsersPage();
            adminManageUsersPage.Show();
        }

        private void adminHomePageTabBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            _adminHomePageTabBtn.BackColor = Color.FromArgb(128, 255, 128);
            adminHomePagePanel.BringToFront();
            Homepage.ActiveForm.Text = "Admin Home Page";
        }

        private void eventsHomePageTabBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            eventsHomePageTabBtn.BackColor = Color.FromArgb(128, 255, 128);
            eventsHomePageTabPanel.BringToFront();
            Homepage.ActiveForm.Text = "Events Home Page";
        }

        private void membershipPageTabBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            membershipPageTabBtn.BackColor = Color.FromArgb(128, 255, 128);

            if (UserSession.User.bIsMember)
                activeMembershipPanel.BringToFront();
            else
            {
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
        }

        private void benefitsDashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            benefitsDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            benefitsPagePanel.BringToFront();
            Homepage.ActiveForm.Text = "Benefits Page";
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

            membershipDescriptionTxtBox.Text = "Membership Name: " + selectedMembership.typeName + "\n\nDescription: " + selectedMembership.description + "\n\nCost: £" +
            selectedMembership.cost.ToString() + "\n\nJoining Fee: £" + selectedMembership.joiningFee.ToString() + "\n\nDuration: " + selectedMembership.duration;
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

                // Delet any requests in the AdminRequests table created at signup
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
                con.Close();

                UserSession.User.bIsMember = true;

                UserSession.Member.memberId = memberId;
                UserSession.Member.userId = currentUserId;
                UserSession.Member.membershipTypeId = selectedMembership.membershipTypeId;

                UserSession.ActiveMembership = selectedMembership;

                UserSession.MembershipTypes.Clear();

                MessageBox.Show("You membership has been updated to " + selectedMembership.typeName + "!");
            }

            activeMembershipPanel.BringToFront();
            activeMembershipPanel.Focus();
        }

        private void activeMembershipPanel_Enter(object sender, EventArgs e)
        {
            var selectedMembership = UserSession.ActiveMembership;

            membershipInfoTxtBox.Text = "Membership Name: " + selectedMembership.typeName + "\n\nDescription: " + selectedMembership.description + "\n\nCost: £" +
            selectedMembership.cost.ToString() + "\n\nJoining Fee: £" + selectedMembership.joiningFee.ToString() + "\n\nDuration: " + selectedMembership.duration;
        }
    }
}
