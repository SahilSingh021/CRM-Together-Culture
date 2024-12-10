using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TogetherCultureCRM.AuthenticationPages;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using TogetherCultureCRM.Classes;
using TogetherCultureCRM.CustomControls;
using System.Text.RegularExpressions;

namespace TogetherCultureCRM.AdminPages
{
    public partial class AdminViewUserEventsAndVisitsPage : Form
    {
        //A new constructor for when we want to create the page with an user in mind
        public AdminViewUserEventsAndVisitsPage(User selectdUser)
        {
            InitializeComponent();
            _selectdUser = selectdUser;
        }

        public AdminViewUserEventsAndVisitsPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Access the connection string from the App.config and open a connection with the database
            Data data = new Data();
            string connectionString = data.ConnectionString;
            List<Event> userEvents = new List<Event>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //Select all userEvents and event details for the selected user 
                string selectSql = @"SELECT
                                        ue.userId, ue.eventId, e.eventId, e.tagId, e.eventName, e.eventDate
                                    FROM 
                                        UserEvents ue
                                    LEFT JOIN 
                                        Event e ON ue.eventId = e.eventId
                                    WHERE 
                                        ue.userId=@userId
                                    ORDER BY 
                                        e.eventDate;";

                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@userId", _selectdUser.userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Event @event = new Event()
                            {
                                eventId = Guid.Parse(reader.GetString(reader.GetOrdinal("eventId"))),
                                tagId = Guid.Parse(reader.GetString(reader.GetOrdinal("tagId"))),
                                eventName = reader.GetString(reader.GetOrdinal("eventName")),
                                eventDate = reader.GetDateTime(reader.GetOrdinal("eventDate"))
                            };

                            //Add data to the userEvents
                            userEvents.Add(@event);
                        }
                    }
                }
            }

            // Load all visitor logs for the selected user
            List<VisitorLog> userVisitorLogs = new List<VisitorLog>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectSql = @"SELECT * FROM VisitorLog WHERE userId=@userId ORDER BY visitDate";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@userId", _selectdUser.userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VisitorLog visitorLog = new VisitorLog()
                            {
                                visitorId = Guid.Parse(reader.GetString(reader.GetOrdinal("visitorId"))),
                                userId = Guid.Parse(reader.GetString(reader.GetOrdinal("userId"))),
                                visitDate = reader.GetDateTime(reader.GetOrdinal("visitDate"))
                            };

                            //Add data to the userVisitorLogs
                            userVisitorLogs.Add(visitorLog);
                        }
                    }
                }
            }

            //Chnage the visible property of noEventsLbl acording to userEvents.Count
            if (userEvents.Count > 0) noEventsLbl.Visible = false;
            else noEventsLbl.Visible = true;

            //Loop over the loaded list userEvents
            int heightCount = 0;
            int widthCount = 0;
            foreach (var Event in userEvents)
            {
                //Create a new CC_DisplayEventCard control for each user loaded and asing the values to exposed properties
                var eventDisplayCard = new CC_DisplayEventCard()
                {
                    EventId = Event.eventId.ToString(),
                    TagId = Event.tagId.ToString(),
                    EventName = Event.eventName,
                    EventDate = Event.eventDate.ToString("dd/MM/yyyy"),
                    EventDay = Event.eventDate.ToString("dddd"),
                    EventTime = "Starting Time: " + Event.eventDate.ToString("t")
                };

                eventDisplayCard.BookEventButtonText = "Booked";
                eventDisplayCard.BookEventButtonBackColor = Color.Silver;
                eventDisplayCard.BookEventButtonEnabled = false;

                //Add the control to the eventBookingPanel
                eventBookingPanel.Controls.Add(eventDisplayCard);

                //Change the location property of the control to make sure they dont overlap
                eventDisplayCard.Location = new Point(widthCount * eventDisplayCard.Size.Width, heightCount * eventDisplayCard.Size.Height);
                eventDisplayCard.Location = new Point(eventDisplayCard.Location.X + (widthCount * 20), eventDisplayCard.Location.Y);

                if (heightCount > 0) eventDisplayCard.Location = new Point(eventDisplayCard.Location.X, eventDisplayCard.Location.Y + (heightCount * 20));

                if (widthCount == 2)
                {
                    heightCount++;
                    widthCount = -1;
                }
                widthCount++;
            }

            if (userVisitorLogs.Count > 0)
            {
                //If there are visitor logs for this user then add them to a string builder with a formated string
                StringBuilder sb = new StringBuilder();
                foreach (var visitorLog in userVisitorLogs)
                {
                    sb.AppendLine($"{_selectdUser.username} visited on the {visitorLog.visitDate.ToString("dd/MM/yyyy")}, at {visitorLog.visitDate.ToString("t")}.");
                }

                //Add the stringbuilder text to the visitorLogTxt
                visitorLogTxt.Text = sb.ToString();
            }
            else visitorLogTxt.Text = "You have not made any visits to Together Culture as of now.";    //Or set message in visitorLogTxt
        }

        private User _selectdUser;
    }
}
