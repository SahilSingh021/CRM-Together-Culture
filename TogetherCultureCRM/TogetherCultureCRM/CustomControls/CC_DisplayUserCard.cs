using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TogetherCultureCRM.CustomControls
{
    //This is the CC_DisplayUserCard custom control class
    public partial class CC_DisplayUserCard : UserControl
    {
        //This is the default constructor executing the InitializeComponent function
        public CC_DisplayUserCard()
        {
            InitializeComponent();
        }

        //Here we are exposing the text of the userIdLbl label for external access
        public string UserIdLbl
        {
            get { return userIdLbl.Text; }
            set { userIdLbl.Text = value; }
        }

        //Here we are exposing the text of the usernameLbl label for external access
        public string UsernameText
        {   
            get { return usernameLbl.Text; }
            set { usernameLbl.Text = value; }
        }

        //Here we are exposing the text of the passwordLbl label for external access
        public string PasswordText
        {
            get { return passwordLbl.Text; }
            set { passwordLbl.Text = value; }
        }

        //Here we are exposing the text of the emailLbl label for external access
        public string EmailText
        {
            get { return emailLbl.Text; }
            set { emailLbl.Text = value; }
        }

        //Here we are exposing the text of the membershipLbl label for external access
        public string MembershipText
        {
            get { return membershipLbl.Text; }
            set { membershipLbl.Text = value; }
        }

        //Here we are exposing the visible property of the membershipLbl label for external access
        public bool MembershipTextVisible
        {
            get { return membershipLbl.Visible; }
            set { membershipLbl.Visible = value; }
        }

        //Here we are exposing the checked property of the isMemberCheckBox checkbox for external access
        public bool IsMember
        {
            get { return isMemberCheckBox.Checked; }
            set { isMemberCheckBox.Checked = value; }
        }

        //Here we are exposing the visible property of the isMemberCheckBox checkbox for external access
        public bool IsMemberVisible
        {
            get { return isMemberCheckBox.Visible; }
            set { isMemberCheckBox.Visible = value; }
        }

        //Here we are exposing the checked property of the isAdminCheckBox checkbox for external access
        public bool IsAdmin
        {
            get { return isAdminCheckBox.Checked; }
            set { isAdminCheckBox.Checked = value; }
        }

        //Here we are exposing the visible property of the isAdminCheckBox checkbox for external access
        public bool IsAdminVisible
        {
            get { return isAdminCheckBox.Visible; }
            set { isAdminCheckBox.Visible = value; }
        }

        //Here we are exposing the checked property of the isBannedCheckBox checkbox for external access
        public bool IsBanned
        {
            get { return isBannedCheckBox.Checked; }
            set { isBannedCheckBox.Checked = value; }
        }

        //Here we are exposing the visible property of the isBannedCheckBox checkbox for external access
        public bool IsBannedVisible
        {
            get { return isBannedCheckBox.Visible; }
            set { isBannedCheckBox.Visible = value; }
        }

        //Here we are exposing the text of the manageBtn button for external access
        public string ManageButtonText
        {
            get { return manageBtn.Text; }
            set { manageBtn.Text = value; }
        }

        //Here we are exposing the Enabled property of the manageBtn button for external access
        public bool ManageButtonEnabled
        {
            get { return manageBtn.Enabled; }
            set { manageBtn.Enabled = value; }
        }

        //Here we are exposing the BackColor property of the manageBtn button for external access
        public Color ManageButtonColor
        {
            get { return manageBtn.BackColor; }
            set { manageBtn.BackColor = value; }
        }

        //Here we are exposing the Click property of the manageBtn button for external access (set only)
        public EventHandler ManageButtonClick
        {
            set
            {
                manageBtn.Click += value;
            }
        }
    }
}
