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

        //This function loads data for the current form
        void LoadData()
        {
            //Get the text from the search bar and clear requestPanel for new controls
            string searchBarText = searchBarTxt.Text;
            requestPanel.Controls.Clear();
            if (searchBarText.Length <= 0) return;

            //Access the connection string from the App.config and open a connection with the database
            Data data = new Data();
            string connectionString = data.ConnectionString;
            List<Event> eventList = new List<Event>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //Select all the evetns which have a similar name to the text the user has typed in the searchbar and order them by eventDate
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

                            //Load the events found to the eventList
                            eventList.Add(@event);
                        }
                    }
                }

                con.Close();
            }


            if (eventList.Count > 0)
            {
                //Loop over all eventList
                int heightCount = 0;
                int widthCount = 0;
                foreach (var Event in eventList)
                {
                    //Create a new CC_DisplayEventCard control and asign data
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
                            //Create a new AdminViewEventDetailsPage and pass the event to the custom constructor we created
                            //Change some page properties and show the newley created page
                            AdminViewEventDetailsPage adminViewEventDetailsPage = new AdminViewEventDetailsPage(Event);
                            adminViewEventDetailsPage.Text = Event.eventName + "'s Details";
                            adminViewEventDetailsPage.Owner = this;
                            adminViewEventDetailsPage.ShowInTaskbar = false;
                            adminViewEventDetailsPage.Show();
                        }
                    };

                    //Add control to requestPanel
                    requestPanel.Controls.Add(eventDisplayCard);

                    //Change the laoction property of each control found so they dont overlap one another
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

        //This function executed when user click a key while focused on the searchbar control
        private void searchBarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Load the data for the page
            LoadData();
        }

        //This function executed when user refocuses on the form
        private void AdminEventSearchPage_Activated(object sender, EventArgs e)
        {
            //Load the data for the page
            LoadData();
        }
    }
}
