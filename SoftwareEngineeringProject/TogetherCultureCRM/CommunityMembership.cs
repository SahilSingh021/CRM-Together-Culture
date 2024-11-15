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
    public partial class CommunityMembership : Form
    {
        public CommunityMembership()
        {
            InitializeComponent();
        }

        

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void place_hire_btn_Click(object sender, EventArgs e)
        {
            PlaceHire newForm = new PlaceHire();
            newForm.ShowDialog();
        }

        private void quick_menu_btn_Click(object sender, EventArgs e)
        {

        }

        private void together_culture_btn_Click(object sender, EventArgs e)
        {

        }

        private void community_membership_title_Click(object sender, EventArgs e)
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

        private void digital_connection_board_btn_Click(object sender, EventArgs e)
        {

        }

        private void online_members_area_btn_Click(object sender, EventArgs e)
        {

        }

        private void community_benefits_btn_Click(object sender, EventArgs e)
        {
            BenefitsNonMember newForm = new BenefitsNonMember();
            newForm.ShowDialog();
        }

        private void why_you_should_join_btn_Click(object sender, EventArgs e)
        {

        }

        
        private void sign_up_btn_Click(object sender, EventArgs e)
        {
            MembershipSignUp newForm = new MembershipSignUp();
            newForm.ShowDialog();
        }
    }
}
