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
    public partial class MembershipSignUp : Form
    {
        public MembershipSignUp()
        {
            InitializeComponent();
        }

        private void sign_up_Click(object sender, EventArgs e)
        {
            MembershipPayment newForm = new MembershipPayment();
            newForm.ShowDialog();
        }
    }
}
