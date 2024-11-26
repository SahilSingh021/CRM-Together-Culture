using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TogetherCultureCRM.AdminPages;
using TogetherCultureCRM.Classes;

namespace TogetherCultureCRM
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void AdminHomePage_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            loggedInLbl.Text = "Logged in: " + UserSession.username;

            if (UserSession.bIsAdmin)
            {
                Button adminHomePageTabBtn = new Button
                {
                    BackColor = System.Drawing.Color.FromArgb(128, 255, 128),
                    Cursor = System.Windows.Forms.Cursors.Hand,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0),
                    ForeColor = System.Drawing.Color.Black,
                    Location = new System.Drawing.Point(0, 477),
                    Name = "adminHomePageTabBtn",
                    Size = new System.Drawing.Size(200, 43),
                    TabIndex = 11,
                    Text = "     Admin Page",
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                    UseVisualStyleBackColor = false
                };

                adminHomePageTabBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
                adminHomePageTabBtn.Click += new System.EventHandler(adminHomePageTabBtn_Click);

                this.dashboard.Controls.Add(adminHomePageTabBtn);
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
            adminHomePagePanel.BringToFront();
            loggedInLbl.BringToFront();
            Homepage.ActiveForm.Text = "Admin Home Page";
        }

        private void eventsHomePageTabBtn_Click(object sender, EventArgs e)
        {
            eventsHomePageTabPanel.BringToFront();
            loggedInLbl.BringToFront();
            Homepage.ActiveForm.Text = "Events Home Page";
        }

        private void membershipPageTabBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
