using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TogetherCultureCRM
{
    public partial class MyMembership : Form
    {
        public MyMembership()
        {
            InitializeComponent();
        }

        private void together_culture_logo_Click(object sender, EventArgs e)
        {

        }

        private void my_membership_title_Click(object sender, EventArgs e)
        {

        }

        private void quick_menu_Click(object sender, EventArgs e)
        {

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
            BenefitsNonMember newForm = new BenefitsNonMember();
            newForm.ShowDialog();
        }

        private void events_btn_Click(object sender, EventArgs e)
        {
            Events_MainPage newForm = new Events_MainPage();
            newForm.ShowDialog();
        }

        private void place_hire_btn_Click(object sender, EventArgs e)
        {
            PlaceHire newForm = new PlaceHire();
            newForm.ShowDialog();
        }

        private void digital_connection_board_Click(object sender, EventArgs e)
        {
            DigitalConnectionBoard newForm = new DigitalConnectionBoard();
            newForm.ShowDialog();
        }

        private void online_members_area_btn_Click(object sender, EventArgs e)
        {
            OnlineMembersArea newForm = new OnlineMembersArea();
            newForm.ShowDialog();
        }

        private void your_membership_benefits_btn_Click(object sender, EventArgs e)
        {
            BenefitsMember newForm = new BenefitsMember();
            newForm.ShowDialog();
        }

        

        private void digital_content_module_btn_Click(object sender, EventArgs e)
        {

        }

        

        private void manage_membership_btn_Click(object sender, EventArgs e)
        {
            ManageMembership newForm = new ManageMembership();
            newForm.ShowDialog();
        }
    }
}
