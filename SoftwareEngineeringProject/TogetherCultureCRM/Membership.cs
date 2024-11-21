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
    public partial class Membership : Form
    {
        public Membership()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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


        private void digital_connection_board_btn_Click(object sender, EventArgs e)
        {

        }

        private void place_hire_btn_Click(object sender, EventArgs e)
        {
            PlaceHire newForm = new PlaceHire();
            newForm.ShowDialog();
        }

        
        private void online_members_area_btn_Click(object sender, EventArgs e)
        {
            OnlineMembersArea newForm = new OnlineMembersArea();
            newForm.ShowDialog();
        }

 

        private void membership_title_Click(object sender, EventArgs e)
        {

        }

        private void together_culture_btn_Click(object sender, EventArgs e)
        {

        }

        private void quick_menu_btn_Click(object sender, EventArgs e)
        {

        }

       

        private void organisational_membership_btn_Click(object sender, EventArgs e)
        {
            OrganisationalMemberships newForm = new OrganisationalMemberships();
            newForm.ShowDialog();
        }

        

        private void individual_membership_btn_Click(object sender, EventArgs e)
        {
            IndividualMemberships newForm = new IndividualMemberships();
            newForm.ShowDialog();
        }

        private void my_membership_btn_Click(object sender, EventArgs e)
        {
            MyMembership newForm = new MyMembership();
            newForm.ShowDialog();
        }
    }
}
