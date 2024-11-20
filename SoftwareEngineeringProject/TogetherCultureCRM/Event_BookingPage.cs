using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TogetherCultureCRM
{
    public partial class Event_BookingPage : Form
    {
        public Event_BookingPage()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Homepage newForm = new Homepage();
            newForm.ShowDialog();
        }

        private void Memebrship_Click(object sender, EventArgs e)
        {
            Membership newForm = new Membership();
            newForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MembershipPayment newForm = new MembershipPayment();    
            newForm.ShowDialog();
        }
    }
}
