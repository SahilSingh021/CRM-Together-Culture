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
    public partial class CC_DisplayDigtialContentModule : UserControl
    {
        public CC_DisplayDigtialContentModule()
        {
            InitializeComponent();
        }

        public string ModuleName
        {
            get { return moduleNameLbl.Text; }
            set { moduleNameLbl.Text = value; }
        }

        public string ModuleDateTime
        {
            get { return moduleDateLbl.Text; }
            set { moduleDateLbl.Text = value; }
        }

        public string BookModuleButtonText
        {
            get { return bookModuleBtn.Text; }
            set { bookModuleBtn.Text = value; }
        }

        public bool BookModuleButtonEnabled
        {
            get { return bookModuleBtn.Enabled; }
            set { bookModuleBtn.Enabled = value; }
        }

        public Color BookModuleButtonBackColor
        {
            get { return bookModuleBtn.BackColor; }
            set { bookModuleBtn.BackColor = value; }
        }

        public EventHandler BookModuleClick
        {
            set
            {
                bookModuleBtn.Click += value;
            }
        }
    }
}
