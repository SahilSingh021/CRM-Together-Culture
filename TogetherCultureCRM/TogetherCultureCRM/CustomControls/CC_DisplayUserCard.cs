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
    public partial class CC_DisplayUserCard : UserControl
    {
        public CC_DisplayUserCard()
        {
            InitializeComponent();
        }

        public string UserIdLbl
        {
            get { return userIdLbl.Text; }
            set { userIdLbl.Text = value; }
        }

        public string UsernameText
        {   
            get { return usernameLbl.Text; }
            set { usernameLbl.Text = value; }
        }

        public string PasswordText
        {
            get { return passwordLbl.Text; }
            set { passwordLbl.Text = value; }
        }

        public string EmailText
        {
            get { return emailLbl.Text; }
            set { emailLbl.Text = value; }
        }

        public string MembershipText
        {
            get { return membershipLbl.Text; }
            set { membershipLbl.Text = value; }
        }

        public bool MembershipTextVisible
        {
            get { return membershipLbl.Visible; }
            set { membershipLbl.Visible = value; }
        }

        public bool IsMember
        {
            get { return isMemberCheckBox.Checked; }
            set { isMemberCheckBox.Checked = value; }
        }

        public bool IsMemberVisible
        {
            get { return isMemberCheckBox.Visible; }
            set { isMemberCheckBox.Visible = value; }
        }

        public bool IsAdmin
        {
            get { return isAdminCheckBox.Checked; }
            set { isAdminCheckBox.Checked = value; }
        }

        public bool IsAdminVisible
        {
            get { return isAdminCheckBox.Visible; }
            set { isAdminCheckBox.Visible = value; }
        }

        public bool IsBanned
        {
            get { return isBannedCheckBox.Checked; }
            set { isBannedCheckBox.Checked = value; }
        }

        public bool IsBannedVisible
        {
            get { return isBannedCheckBox.Visible; }
            set { isBannedCheckBox.Visible = value; }
        }

        public string ManageButtonText
        {
            get { return manageBtn.Text; }
            set { manageBtn.Text = value; }
        }

        public bool ManageButtonEnabled
        {
            get { return manageBtn.Enabled; }
            set { manageBtn.Enabled = value; }
        }

        public Color ManageButtonColor
        {
            get { return manageBtn.BackColor; }
            set { manageBtn.BackColor = value; }
        }

        public EventHandler ManageButtonClick
        {
            set
            {
                manageBtn.Click += value;
            }
        }
    }
}
