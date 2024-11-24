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

        public string EmailText
        {
            get { return emailLbl.Text; }
            set { emailLbl.Text = value; }
        }

        public bool IsAdmin
        {
            get { return isAdminCheckBox.Checked; }
            set { isAdminCheckBox.Checked = value; }
        }

        public bool IsBanned
        {
            get { return isBannedCheckBox.Checked; }
            set { isBannedCheckBox.Checked = value; }
        }
    }
}
