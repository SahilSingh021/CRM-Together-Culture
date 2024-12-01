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
    public partial class CC_Request : UserControl
    {
        public CC_Request()
        {
            InitializeComponent();
        }

        private void Request_Load(object sender, EventArgs e)
        {

        }

        public string UsernameLbl
        {
            get { return usernameTxt.Text; }
            set { usernameTxt.Text = value; }
        }
        public string DescriptionLbl
        {
            get { return requestDescription.Text; }
            set { requestDescription.Text = value; }
        }

        public string AdminRequestIdLbl
        {
            get { return adminRequestIdLbl.Text; }
            set { adminRequestIdLbl.Text = value; }
        }

        public EventHandler ApproveButtonClick
        {
            set
            {
                approveBtn.Click += value;
            }
        }

        public EventHandler DenyButtonClick
        {
            set
            {
                denyBtn.Click += value;
            }
        }
    }
}
