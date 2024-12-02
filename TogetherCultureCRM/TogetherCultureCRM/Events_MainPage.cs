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
    public partial class Events_MainPage : Form
    {
        public Events_MainPage()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Homepage newForm = new Homepage();
            newForm.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        

        private void Place_hire_Click(object sender, EventArgs e)
        {
            PlaceHire newForm = new PlaceHire();
            newForm.ShowDialog();
        }

        private void Book_Click(object sender, EventArgs e)
        {
            Event_BookingPage newForm = new Event_BookingPage();
            newForm.ShowDialog();
        }

        private void Book_event1_Click(object sender, EventArgs e)
        {
            Event_BookingPage newForm = new Event_BookingPage();
            newForm.ShowDialog();
        }

        private void Book_Event2_Click(object sender, EventArgs e)
        {
            Event_BookingPage newForm = new Event_BookingPage();
            newForm.ShowDialog();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            
        }

        

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Homepage newForm = new Homepage();
            newForm.ShowDialog();
        }
    }
}
