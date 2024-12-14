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
    //This is the CC_Request custom control class
    public partial class CC_Request : UserControl
    {
        //This is the default constructor executing the InitializeComponent function
        public CC_Request()
        {
            InitializeComponent();
        }

        //Here we are exposing the text of the usernameTxt label for external access
        public string UsernameLbl
        {
            get { return usernameTxt.Text; }
            set { usernameTxt.Text = value; }
        }

        //Here we are exposing the text of the requestDescriptionLbl label for external access
        public string DescriptionLbl
        {
            get { return requestDescriptionLbl.Text; }
            set { requestDescriptionLbl.Text = value; }
        }

        //Here we are exposing the text of the adminRequestIdLbl label for external access
        public string AdminRequestIdLbl
        {
            get { return adminRequestIdLbl.Text; }
            set { adminRequestIdLbl.Text = value; }
        }

        //Here we are exposing the Click property of the approveBtn button for external access (set only)
        public EventHandler ApproveButtonClick
        {
            set
            {
                approveBtn.Click += value;
            }
        }

        //Here we are exposing the Click property of the denyBtn button for external access (set only)
        public EventHandler DenyButtonClick
        {
            set
            {
                denyBtn.Click += value;
            }
        }
    }
}
