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
    //This is the CC_HomeInterestTagButton custom control class
    public partial class CC_HomeInterestTagButton : UserControl
    {
        //This is the default constructor executing the InitializeComponent function
        public CC_HomeInterestTagButton()
        {
            InitializeComponent();
        }

        //Here we are exposing the text of the tagIdLbl label for external access
        public string TagId
        {
            get { return tagIdLbl.Text; }
            set { tagIdLbl.Text = value; }
        }

        //Here we are exposing the text of the intrestTagBtn button for external access
        public string IntrestTagButtonText
        {
            get { return intrestTagBtn.Text; }
            set { intrestTagBtn.Text = value; }
        }

        //Here we are exposing the BackColor property of the intrestTagBtn button for external access
        public Color IntrestTagButtonBackColor
        {
            get { return intrestTagBtn.BackColor; }
            set { intrestTagBtn.BackColor = value; }
        }

        //Here we are exposing the Click property of the intrestTagBtn button for external access (set only)
        public EventHandler IntrestTagButtonClick
        {
            set
            {
                intrestTagBtn.Click += value;
            }
        }
    }
}
