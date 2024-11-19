using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TogetherCultureCRM
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void membership_btn_Click(object sender, EventArgs e)
        {
            Membership newForm = new Membership();
            newForm.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void benefits_btn_Click(object sender, EventArgs e)
        {
            BenefitsMember newForm = new BenefitsMember();
            newForm.ShowDialog();
        }

        private void events_btn_Click(object sender, EventArgs e)
        {
            Events_MainPage newForm = new Events_MainPage();
            newForm.ShowDialog();
        }
    }
}
