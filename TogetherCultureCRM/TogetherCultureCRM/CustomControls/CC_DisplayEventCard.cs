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
    //This is the CC_DisplayEventCard custom control class
    public partial class CC_DisplayEventCard : UserControl
    {
        //This is the default constructor executing the InitializeComponent function
        public CC_DisplayEventCard()
        {
            InitializeComponent();
        }

        //Here we are exposing the text of the eventIdLbl label for external access
        public string EventId
        {
            get { return eventIdLbl.Text; }
            set { eventIdLbl.Text = value; }
        }

        //Here we are exposing the text of the tagIdLbl label for external access
        public string TagId
        {
            get { return tagIdLbl.Text; }
            set { tagIdLbl.Text = value; }
        }

        //Here we are exposing the text of the eventDayLbl label for external access
        public string EventDay
        {
            get { return eventDayLbl.Text; }
            set { eventDayLbl.Text = value; }
        }

        //Here we are exposing the text of the eventDateLbl label for external access
        public string EventDate
        {
            get { return eventDateLbl.Text; }
            set { eventDateLbl.Text = value; }
        }

        //Here we are exposing the text of the eventNameLbl label for external access
        public string EventName
        {
            get { return eventNameLbl.Text; }
            set { eventNameLbl.Text = value; }
        }

        //Here we are exposing the text of the eventTimeLbl label for external access
        public string EventTime
        {
            get { return eventTimeLbl.Text; }
            set { eventTimeLbl.Text = value; }
        }

        //Here we are exposing the text of the bookEventBtn button for external access
        public string BookEventButtonText
        {
            get { return bookEventBtn.Text; }
            set { bookEventBtn.Text = value; }
        }

        //Here we are exposing the Enabled property of the bookEventBtn button for external access
        public bool BookEventButtonEnabled
        {
            get { return bookEventBtn.Enabled; }
            set { bookEventBtn.Enabled = value; }
        }

        //Here we are exposing the BackColor property of the bookEventBtn button for external access
        public Color BookEventButtonBackColor
        {
            get { return bookEventBtn.BackColor; }
            set { bookEventBtn.BackColor = value; }
        }

        //Here we are exposing the Click property of the bookEventBtn button for external access (set only)
        public EventHandler BookEventClick
        {
            set
            {
                bookEventBtn.Click += value;
            }
        }
    }
}
