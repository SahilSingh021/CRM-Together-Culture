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


        private void community_btn_Click(object sender, EventArgs e)
        {
            CommunityMembership newForm = new CommunityMembership();
            newForm.ShowDialog();
        }

        private void workplace_btn_Click(object sender, EventArgs e)
        {
            WorkplaceMembership newForm = new WorkplaceMembership();
            newForm.ShowDialog();
        }

        

        private void home_btn_Click(object sender, EventArgs e)
        {

        }

        

        private void profile_btn_Click(object sender, EventArgs e)
        {

        }

       
        private void benefits_btn_Click(object sender, EventArgs e)
        {

        }

        

        private void events_btn_Click(object sender, EventArgs e)
        {

        }


        private void digital_connection_board_btn_Click(object sender, EventArgs e)
        {

        }

        private void place_hire_btn_Click(object sender, EventArgs e)
        {

        }

        
        private void online_members_area_btn_Click(object sender, EventArgs e)
        {

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
    }
}
