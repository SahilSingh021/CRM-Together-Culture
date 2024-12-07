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
    public partial class CC_HomeInterestTagButton : UserControl
    {
        public CC_HomeInterestTagButton()
        {
            InitializeComponent();
        }

        public string TagId
        {
            get { return tagIdLbl.Text; }
            set { tagIdLbl.Text = value; }
        }

        public string IntrestTagButtonText
        {
            get { return intrestTagBtn.Text; }
            set { intrestTagBtn.Text = value; }
        }

        public Color IntrestTagButtonBackColor
        {
            get { return intrestTagBtn.BackColor; }
            set { intrestTagBtn.BackColor = value; }
        }

        public EventHandler IntrestTagButtonClick
        {
            set
            {
                intrestTagBtn.Click += value;
            }
        }
    }
}
