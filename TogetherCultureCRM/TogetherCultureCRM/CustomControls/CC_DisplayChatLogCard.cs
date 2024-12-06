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
    public partial class CC_DisplayChatLogCard : UserControl
    {
        public CC_DisplayChatLogCard()
        {
            InitializeComponent();
        }

        public string UsernameAndDateText
        {
            get { return usernameDateLbl.Text; }
            set { usernameDateLbl.Text = value; }
        }

        public string ChatMessageText
        {
            get { return chatMsgLbl.Text; }
            set { chatMsgLbl.Text = value; }
        }
    }
}
