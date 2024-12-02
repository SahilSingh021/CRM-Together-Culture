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
    public partial class CC_DisplayEventCard : UserControl
    {
        public CC_DisplayEventCard()
        {
            InitializeComponent();
        }

        public string EventId
        {
            get { return eventIdLbl.Text; }
            set { eventIdLbl.Text = value; }
        }
        public string TagId
        {
            get { return tagIdLbl.Text; }
            set { tagIdLbl.Text = value; }
        }

        public string EventDate
        {
            get { return eventDateLbl.Text; }
            set { eventDateLbl.Text = value; }
        }

        public string EventName
        {
            get { return eventNameLbl.Text; }
            set { eventNameLbl.Text = value; }
        }

        public string EventTime
        {
            get { return eventTimeLbl.Text; }
            set { eventTimeLbl.Text = value; }
        }

        public EventHandler BookEventClick
        {
            set
            {
                bookEventBtn.Click += value;
            }
        }
    }
}
