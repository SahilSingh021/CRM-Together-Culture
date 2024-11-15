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
    public partial class IndividualMemberships : Form
    {
        public IndividualMemberships()
        {
            InitializeComponent();
        }

        private void community_membership_btn_Click(object sender, EventArgs e)
        {
            CommunityMembership newForm = new CommunityMembership();
            ShowDialog(newForm);
        }

        private void workplace_membership_btn_Click(object sender, EventArgs e)
        {
            WorkplaceMembership newForm = new WorkplaceMembership();
            ShowDialog(newForm);
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            Homepage newForm = new Homepage();
            ShowDialog(newForm);
        }

        private void profile_btn_Click(object sender, EventArgs e)
        {

        }

        private void membership_btn_Click(object sender, EventArgs e)
        {
            Membership newForm = new Membership();
            ShowDialog(newForm);
        }

        private void benefits_btn_Click(object sender, EventArgs e)
        {
            BenefitsNonMember newForm = new BenefitsNonMember();
            ShowDialog(newForm);
        }

        private void events_btn_Click(object sender, EventArgs e)
        {
            Events_MainPage newForm = new Events_MainPage();    
            ShowDialog(newForm);
        }

        private void place_hire_btn_Click(object sender, EventArgs e)
        {
            PlaceHire newForm = new PlaceHire();
            ShowDialog(newForm);
        }

        private void digital_connection_board_btn_Click(object sender, EventArgs e)
        {
            DigitalConnectionBoard newForm = new DigitalConnectionBoard();
            ShowDialog(newForm);
        }

        private void online_members_area_btn_Click(object sender, EventArgs e)
        {
            OnlineMembersArea newForm = new OnlineMembersArea();
            ShowDialog(newForm);
        }
    }
}
