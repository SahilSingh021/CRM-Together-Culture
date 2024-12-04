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

namespace TogetherCultureCRM.AdminPages
{
    public partial class AdminEventSearchPage : Form
    {
        public AdminEventSearchPage()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            string searchBarText = searchBarTxt.Text;
            requestPanel.Controls.Clear();
            if (searchBarText.Length <= 0) return;

            Data data = new Data();
            string connectionString = data.ConnectionString;
            List<Event> eventList = new List<Event>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectSql = @"SELECT * FROM Event WHERE LOWER(eventName) LIKE LOWER(@searchText) + '%' ORDER BY eventDate;";

                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@searchText", searchBarText);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Event @event = new Event()
                            {
                                eventId = Guid.Parse(reader.GetString(reader.GetOrdinal("eventId"))),
                                tagId = Guid.Parse(reader.GetString(reader.GetOrdinal("tagId"))),
                                eventName = reader.GetString(reader.GetOrdinal("eventName")),
                                eventDate = reader.GetDateTime(reader.GetOrdinal("eventDate")),
                            };

                            eventList.Add(@event);
                        }
                    }
                }

                con.Close();
            }


            if (eventList.Count > 0)
            {
                int heightCount = 0;
                int widthCount = 0;
                foreach (var Event in eventList)
                {
                    var eventDisplayCard = new CC_DisplayEventCard()
                    {
                        EventId = Event.eventId.ToString(),
                        TagId = Event.tagId.ToString(),
                        EventName = Event.eventName,
                        EventDate = Event.eventDate.ToString("dd/MM/yyyy"),
                        EventDay = Event.eventDate.ToString("dddd"),
                        EventTime = "Starting Time: " + Event.eventDate.ToString("t"),
                        BookEventButtonText = "View Event Details",
                        BookEventClick = (s, eventArg) =>
                        {
                            AdminViewEventDetailsPage adminViewEventDetailsPage = new AdminViewEventDetailsPage(Event);
                            adminViewEventDetailsPage.Text = Event.eventName + "'s Details";
                            adminViewEventDetailsPage.Owner = this;
                            adminViewEventDetailsPage.ShowInTaskbar = false;
                            adminViewEventDetailsPage.Show();
                        }
                    };

                    requestPanel.Controls.Add(eventDisplayCard);

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
            }
        }

        private void searchBarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoadData();
        }

        private void AdminUserEventSearchPage_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
