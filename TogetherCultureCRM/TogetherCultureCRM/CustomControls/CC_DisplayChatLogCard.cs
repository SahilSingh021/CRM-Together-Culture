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
    //This is the CC_DisplayChatLogCard custom control class
    public partial class CC_DisplayChatLogCard : UserControl
    {
        //This is the default constructor executing the InitializeComponent function
        public CC_DisplayChatLogCard()
        {
            InitializeComponent();
        }

        //Here we are exposing the text of the usernameDateLbl label for external access
        public string UsernameAndDateText
        {
            get { return usernameDateLbl.Text; }
            set { usernameDateLbl.Text = value; }
        }

        //Here we are exposing the text of the chatMsgLbl label for external access
        public string ChatMessageText
        {
            get { return chatMsgLbl.Text; }
            set { chatMsgLbl.Text = value; }
        }
    }
}
