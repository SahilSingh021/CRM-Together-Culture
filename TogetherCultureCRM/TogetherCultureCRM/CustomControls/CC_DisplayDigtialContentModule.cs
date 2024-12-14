using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TogetherCultureCRM.CustomControls
{
    //This is the CC_DisplayDigtialContentModule custom control class
    public partial class CC_DisplayDigtialContentModule : UserControl
    {
        //This is the default constructor executing the InitializeComponent function
        public CC_DisplayDigtialContentModule()
        {
            InitializeComponent();
        }

        //Here we are exposing the text of the moduleNameLbl label for external access
        public string ModuleName
        {
            get { return moduleNameLbl.Text; }
            set { moduleNameLbl.Text = value; }
        }

        //Here we are exposing the text of the moduleDateLbl label for external access
        public string ModuleDate
        {
            get { return moduleDateLbl.Text; }
            set { moduleDateLbl.Text = value; }
        }

        //Here we are exposing the visible property of the moduleDateLbl label for external access
        public bool ModuleDateVisible
        {
            get { return moduleDateLbl.Visible; }
            set { moduleDateLbl.Visible = value; }
        }


        //Here we are exposing the text of the bookModuleBtn button for external access
        public string BookModuleButtonText
        {
            get { return bookModuleBtn.Text; }
            set { bookModuleBtn.Text = value; }
        }

        //Here we are exposing the Enabled property of the bookModuleBtn button for external access
        public bool BookModuleButtonEnabled
        {
            get { return bookModuleBtn.Enabled; }
            set { bookModuleBtn.Enabled = value; }
        }

        //Here we are exposing the BackColor property of the bookModuleBtn button for external access
        public Color BookModuleButtonBackColor
        {
            get { return bookModuleBtn.BackColor; }
            set { bookModuleBtn.BackColor = value; }
        }

        //Here we are exposing the Click property of the bookModuleBtn button for external access (set only)
        public EventHandler BookModuleButtonClick
        {
            set
            {
                bookModuleBtn.Click += value;
            }
        }
    }
}
