using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TogetherCultureCRM.Classes;

namespace TogetherCultureCRM.AdminPages
{
    public partial class AdminHomePage : Form
    {
        public AdminHomePage()
        {
            InitializeComponent();
        }

        private void AdminHomePage_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            loggedInLbl.Text = "Logged in: " + UserSession.username;
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
    }
}
