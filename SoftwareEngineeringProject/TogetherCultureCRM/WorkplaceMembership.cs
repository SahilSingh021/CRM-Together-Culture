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
    public partial class WorkplaceMembership : Form
    {
        public WorkplaceMembership()
        {
            InitializeComponent();
        }

        private void workplace_membership_title_Click(object sender, EventArgs e)
        {

        }

        private void together_culture_logo_Click(object sender, EventArgs e)
        {

        }

        private void why_you_should_join_btn_Click(object sender, EventArgs e)
        {

        }

        private void sign_up_btn_Click(object sender, EventArgs e)
        {

        }

        private void workplace_benefits_btn_Click(object sender, EventArgs e)
        {
            Benefits_Non_Member newForm = new Benefits_Non_Member();
            newForm.ShowDialog();
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            Homepage newForm = new Homepage();
            newForm.ShowDialog();
        }

        private void profile_btn_Click(object sender, EventArgs e)
        {

        }

        private void membership_btn_Click(object sender, EventArgs e)
        {
            Membership newForm = new Membership();
            newForm.ShowDialog();
        }

        private void benefits_btn_Click(object sender, EventArgs e)
        {
            Benefits_Non_Member newForm = new Benefits_Non_Member();
            newForm.ShowDialog();
        }

        private void events_btn_Click(object sender, EventArgs e)
        {
            Events_MainPage newForm = new Events_MainPage();
            newForm.ShowDialog();
        }

        private void place_hire_btn_Click(object sender, EventArgs e)
        {
            Place_Hire newForm = new Place_Hire();
            newForm.ShowDialog();
        }

        private void digital_connection_board_btn_Click(object sender, EventArgs e)
        {

        }

        private void online_members_area_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
