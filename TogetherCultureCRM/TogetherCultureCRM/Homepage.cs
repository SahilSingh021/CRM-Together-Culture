using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TogetherCultureCRM.AdminPages;
using TogetherCultureCRM.Classes;
using TogetherCultureCRM.CustomControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TogetherCultureCRM
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        //Function executes when the form is closing and if it is it closes the app as this is a parent form
        private void AdminHomePage_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        //Instance of the AdminHomePage Button as its being created at runtime
        private Button _adminHomePageTabBtn;

        //This function executes when the HomePage is loaded
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Set the username for the logged in user on the top left of the app
            loggedInLbl.Text = UserSession.User.username;

            //Bring the HomePage pannel to the front and change the color of the Home dashboard button to the 'selected button' color and rename the window name to 'Home Page'
            homePagePanel.BringToFront();
            homeDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            Homepage.ActiveForm.Text = "Home Page";

            //If the current user is an Admin then create the Admin dashboard button and add it to the dashboard
            if (UserSession.User.bIsAdmin)
            {
                _adminHomePageTabBtn = new Button
                {
                    BackColor = Color.FromArgb(247, 255, 247),
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    ForeColor = Color.Black,
                    Location = new Point(0, 477),
                    Name = "adminHomePageTabBtn",
                    Size = new Size(200, 43),
                    TabIndex = 11,
                    Text = "     Admin Page",
                    TextAlign = ContentAlignment.MiddleLeft,
                    UseVisualStyleBackColor = false,
                };

                _adminHomePageTabBtn.FlatAppearance.BorderColor = Color.Silver;
                _adminHomePageTabBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
                //Assign the dashboard button a function to execute when its clicked by the user
                _adminHomePageTabBtn.Click += new EventHandler(adminHomePageTabBtn_Click);

                //Add the controll to the dashbaord pannel
                dashboard.Controls.Add(_adminHomePageTabBtn);
            }

            //Call the LoadHomePanelData function
            LoadHomePanelData();
        }

        //Function to reset all the dashboard buttons BackColor property
        public void DashboardBtn_BackColorReset()
        {
            Color col = Color.FromArgb(247, 255, 247);
            homeDashboardBtn.BackColor = col;
            profileDashboardBtn.BackColor = col;
            membershipPageTabBtn.BackColor = col;
            benefitsDashboardBtn.BackColor = col;
            eventsHomePageTabBtn.BackColor = col;
            digitalConnectionDashboardBtn.BackColor = col;
            onlineMembersAreadDashboardBtn.BackColor = col;
            digitalContentDashboardBtn.BackColor = col;

            if (UserSession.User.bIsAdmin && _adminHomePageTabBtn != null)
            {
                _adminHomePageTabBtn.BackColor = col;
            }
        }

        //This function is called when the Admin clicks the Manage Requests button
        private void manageRequestsBtn_Click(object sender, EventArgs e)
        {
            //Show the AdminRequestsPage and set the current form as the parent form and make sure the AdminRequestsPage dosnt show in the taskbar
            AdminRequestsPage adminRequestsPage = new AdminRequestsPage();
            adminRequestsPage.Owner = this;
            adminRequestsPage.ShowInTaskbar = false;
            adminRequestsPage.Show();
        }

        //This function is called when the Admin clicks the Manage Requests button
        private void manageUserBtn_Click(object sender, EventArgs e)
        {
            //Show the AdminManageUsersPage and set the current form as the parent form and make sure the AdminManageUsersPage dosnt show in the taskbar
            AdminManageUsersPage adminManageUsersPage = new AdminManageUsersPage();
            adminManageUsersPage.Owner = this;
            adminManageUsersPage.ShowInTaskbar = false;
            adminManageUsersPage.Show();
        }

        //This function is called when the Admin clicks the User Search button
        private void userEventSearchBtn_Click(object sender, EventArgs e)
        {
            //Show the AdminUserEventSearchPage and set the current form as the parent form and make sure the AdminUserEventSearchPage dosnt show in the taskbar
            AdminUserEventSearchPage adminUserEventSearchPage = new AdminUserEventSearchPage();
            adminUserEventSearchPage.Owner = this;
            adminUserEventSearchPage.ShowInTaskbar = false;
            adminUserEventSearchPage.Show();
        }

        //This function is called when the Admin clicks the Event Search button
        private void eventSearchBtn_Click(object sender, EventArgs e)
        {
            //Show the AdminEventSearchPage and set the current form as the parent form and make sure the AdminEventSearchPage dosnt show in the taskbar
            AdminEventSearchPage adminEventSearchPage = new AdminEventSearchPage();
            adminEventSearchPage.Owner = this;
            adminEventSearchPage.ShowInTaskbar = false;
            adminEventSearchPage.Show();
        }

        //This function is called when the Admin clicks the All Users button
        private void allUsersBtn_Click(object sender, EventArgs e)
        {
            //Show the AdminAllUsersPage and set the current form as the parent form and make sure the AdminAllUsersPage dosnt show in the taskbar
            AdminAllUsersPage adminAllUsersPage = new AdminAllUsersPage();
            adminAllUsersPage.Owner = this;
            adminAllUsersPage.ShowInTaskbar = false;
            adminAllUsersPage.Show();
        }

        //This function loads all the AdminHomePage data
        public void LoadAdminHomePageData()
        {
            //Create a new Dictionary which take a string as the key and stores int as the value
            Dictionary<string, int> storage = new Dictionary<string, int>();
            //Access the connection string from the App.config and open a connection with the database
            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;

            //This query stores the name of the table as TableName and then stores number of records in that table as RecordCount for Users, Admin, Member, DigitalContentModule and the Event table
            string selectSql = @"SELECT 'Users' AS TableName, COUNT(*) AS RecordCount FROM Users
                             UNION ALL
                             SELECT 'Admin' AS TableName, COUNT(*) AS RecordCount FROM Admin
                             UNION ALL
                             SELECT 'Member' AS TableName, COUNT(*) AS RecordCount FROM Member
                             UNION ALL
                             SELECT 'DigitalContentModule' AS TableName, COUNT(*) AS RecordCount FROM DigitalContentModule
                             UNION ALL
                             SELECT 'Event' AS TableName, COUNT(*) AS RecordCount FROM Event;
            ";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //Read all that is returned from the db and store it inside the Dictionary 'storage' we created above as a key and value pair
                        while (reader.Read())
                        {
                            string tableName = reader.GetString(reader.GetOrdinal("TableName"));
                            int recordCount = reader.GetInt32(reader.GetOrdinal("RecordCount"));

                            storage[tableName] = recordCount;
                        }
                    }
                }
            }

            //Get the data from the Dictionary 'storage' and set the Text property of each lable on the AdminHomePage to the correct key and value
            totalNumberOfUsersLbl.Text = "Total Number of Users: " + storage["Users"].ToString();
            totalNumberOfAdminsLbl.Text = "Total Number of Admins: " + storage["Admin"].ToString();
            totalNumberOfMembersLbl.Text = "Total Number of Members: " + storage["Member"].ToString();
            totalNumberOfDigitalContentMdulesLbl.Text = "Total Number of Digital Content Modules: " + storage["DigitalContentModule"].ToString();
            totalNumberOfEventsLbl.Text = "Total Number of Events: " + storage["Event"].ToString();
        }

        //This function executes when the user clicks Admin HomePage button in the dashboard
        private void adminHomePageTabBtn_Click(object sender, EventArgs e)
        {
            //Reset dashboard buttons colors, set the back color of the dashboard button that is clicked to the 'selectd button' color and rename the window name
            DashboardBtn_BackColorReset();
            _adminHomePageTabBtn.BackColor = Color.FromArgb(128, 255, 128);
            adminHomePagePanel.BringToFront();
            Homepage.ActiveForm.Text = "Admin Home Page";

            //Call LoadAdminHomePageData to load all the data to the admin homepage pannel
            LoadAdminHomePageData();
        }

        //This function is used to book an event for the the current user
        public void BookEvent(Guid eventId, Guid tagId)
        {
            //Confirm if the user wants to book the event
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to book this event?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                //If they confirm then access the connection string from the App.config and open a connection with the database
                bool tagIdFound = false;    // This is to check if the user has already been assigned the interest tag associated with this event
                Data dataCls = new Data();
                string connectionString = dataCls.ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    //Insert record into UserEvents for the current user
                    string insertSql = "INSERT INTO UserEvents (eventId, userId) VALUES (@eventId, @userId)";
                    using (SqlCommand command = new SqlCommand(insertSql, con))
                    {
                        command.Parameters.AddWithValue("@eventId", eventId);
                        command.Parameters.AddWithValue("@userId", UserSession.User.userId);

                        command.ExecuteNonQuery();
                    }

                    //Check if UserTag record already exists for the current user
                    string selectSql = @"SELECT * FROM UserTag WHERE userId=@userId AND tagId=@tagId";
                    using (SqlCommand command = new SqlCommand(selectSql, con))
                    {
                        command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                        command.Parameters.AddWithValue("@tagId", tagId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //If it does already exists then set 'tagIdFound' to true
                                tagIdFound = true;
                            }
                        }
                    }

                    if (!tagIdFound)
                    {
                        //If UserTag record dosn't exists Insert record into UserTag for the current user
                        string insertSql1 = "INSERT INTO UserTag (userId, tagId) VALUES (@userId, @tagId)";
                        using (SqlCommand command = new SqlCommand(insertSql1, con))
                        {
                            command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                            command.Parameters.AddWithValue("@tagId", tagId);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                //Show success message to the user and refresh the events page by 'eventsHomePageTabBtn.PerformClick();'
                MessageBox.Show("You have booked this Event!", "Event Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                eventsHomePageTabBtn.PerformClick();
            }
        }

        //This function executes when the user clicks Events page button in the dashboard
        private void eventsHomePageTabBtn_Click(object sender, EventArgs e)
        {
            //Clear eventBookingPanel for fresh new records to be inserted
            //Reset dashboard buttons colors, set the back color of the dashboard button that is clicked to the 'selectd button' color and rename the window name
            eventBookingPanel.Controls.Clear();
            DashboardBtn_BackColorReset();
            eventsHomePageTabBtn.BackColor = Color.FromArgb(128, 255, 128);
            eventsHomePageTabPanel.BringToFront();
            Homepage.ActiveForm.Text = "Events Home Page";

            //Create a list of Guids to store all the eventId's that the current user is already booked too (for comparison purposes)
            List<Guid> eventIds = new List<Guid>();
            //Access the connection string from the App.config and open a connection with the database
            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //Load all user events eventIds that have been booked by the current user into eventIds
                string selectSql = "SELECT * FROM UserEvents WHERE userId=@userId";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            eventIds.Add(Guid.Parse(reader.GetString(reader.GetOrdinal("eventId"))));
                        }
                    }
                }
            }

            //Loop through every event avaliable to all users
            int heightCount = 0;
            int widthCount = 0;
            foreach (var Event in UserSession.Events)
            {
                //Check if the current event that is being looped has already been booked by the user by comapring the eventId properties
                //If it has already been booked then set 'eventBooked' to true
                bool eventBooked = false;
                foreach (var evenId in eventIds)
                {
                    if (evenId == Event.eventId) eventBooked = true;
                }

                //Create a new instance of the CC_DisplayEventCard custom control and assign the appropriate details to the exposed properties
                var eventDisplayCard = new CC_DisplayEventCard()
                {
                    EventId = Event.eventId.ToString(),
                    TagId = Event.tagId.ToString(),
                    EventName = Event.eventName,
                    EventDate = Event.eventDate.ToString("dd/MM/yyyy"),
                    EventDay = Event.eventDate.ToString("dddd"),
                    EventTime = "Starting Time: " + Event.eventDate.ToString("t"),
                    BookEventClick = (s, eventArg) =>
                    {
                        //Call the BookEvent function to book the current event
                        BookEvent(Guid.Parse(Event.eventId.ToString()), Guid.Parse(Event.tagId.ToString()));
                    }
                };

                if (eventBooked)
                {
                    //If this event is already booked by the user then block the user from rebooking it and chnage color and text of the button
                    eventDisplayCard.BookEventButtonText = "Booked";
                    eventDisplayCard.BookEventButtonBackColor = Color.Silver;
                    eventDisplayCard.BookEventButtonEnabled = false;
                }

                //Add the event to the eventBookingPanel
                eventBookingPanel.Controls.Add(eventDisplayCard);

                //Modif the location of the control that has been added to the eventBookingPanel so they do not overlap one another
                // Modifies the width and height of the card
                eventDisplayCard.Location = new Point(widthCount * eventDisplayCard.Size.Width, heightCount * eventDisplayCard.Size.Height);

                // Adds gap (width) between cards
                eventDisplayCard.Location = new Point(eventDisplayCard.Location.X + (widthCount * 20), eventDisplayCard.Location.Y);

                // Adds gap (height) between cards
                if (heightCount > 0) eventDisplayCard.Location = new Point(eventDisplayCard.Location.X, eventDisplayCard.Location.Y + (heightCount * 20));

                if (widthCount == 3)
                {
                    heightCount++;
                    widthCount = -1;
                }
                widthCount++;
            }
        }

        //This function executes when the user clicks Membership page button in the dashboard
        private void membershipPageTabBtn_Click(object sender, EventArgs e)
        {
            //Reset dashboard buttons colors, set the back color of the dashboard button that is clicked to the 'selectd button' color
            DashboardBtn_BackColorReset();
            membershipPageTabBtn.BackColor = Color.FromArgb(128, 255, 128);

            if (UserSession.User.bIsMember)
            {
                //If the current user is a member then get their active membership, laod the active membership to the labels on the activeMembershipPanel and bring it to the front
                var selectedMembership = UserSession.ActiveMembership;

                membershipNameLbl.Text = "Membership Name: " + selectedMembership.typeName;
                descriptionLbl.Text = "Description: " + selectedMembership.description;
                costLbl.Text = "Cost: £" + selectedMembership.cost.ToString();
                joiningFeeLbl.Text = "Joining Fee: £" + selectedMembership.joiningFee.ToString();
                durationLbl.Text = "Duration: " + selectedMembership.duration;

                activeMembershipPanel.BringToFront();
            }
            else
            {
                //If the current user is not a member clear all itms in membershipDropBox and the List of 'MembershipTypes' class instance for new data
                membershipDropBox.Items.Clear();
                UserSession.MembershipTypes.Clear();

                //Access the connection string from the App.config and open a connection with the database
                Data data = new Data();
                string connectionString = data.ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    //Load all MembershipType into the List of 'MembershipTypes' class instance in the static 'UserSession' class
                    string selectMembershipTypeSql = "SELECT * FROM MembershipType";
                    using (SqlCommand command1 = new SqlCommand(selectMembershipTypeSql, con))
                    {
                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                MembershipType membershipType = new MembershipType()
                                {
                                    membershipTypeId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("membershipTypeId"))),
                                    typeName = reader1.GetString(reader1.GetOrdinal("typeName")),
                                    description = reader1.GetString(reader1.GetOrdinal("description")),
                                    cost = reader1.GetDecimal(reader1.GetOrdinal("cost")),
                                    joiningFee = reader1.GetDecimal(reader1.GetOrdinal("joiningFee")),
                                    duration = reader1.GetString(reader1.GetOrdinal("duration"))
                                };

                                UserSession.MembershipTypes.Add(membershipType);
                            }
                        }
                    }
                }

                foreach (var membershipType in UserSession.MembershipTypes)
                {
                    //Add all the loaded MembershipTypes 'typeName' property to the membershipDropBox
                    membershipDropBox.Items.Add(membershipType.typeName);
                }

                //Bring membershipPanel to the front
                membershipPanel.BringToFront();
            }

            //Rename the window name
            Homepage.ActiveForm.Text = "Membership Page";
        }

        //This function loads events related to the tag button clicked by the user into the eventSearchPanel
        public void LoadClickedIntrestTagEvents_IntoEventSearchPanel(Guid tagId)
        {
            //Clear the search bar text and clear eventSearchPanel for new controls
            searchBarTxt.Text = "";
            eventSearchPanel.Controls.Clear();

            //Create a List<Guid> eventIds to load all the event ids the user has already booked for comparison
            List<Guid> eventIds = new List<Guid>();
            //Create List<Event> events to load all events that are related to the tag clicked
            List<Event> events = new List<Event>();

            //Access the connection string from the App.config and open a connection with the database
            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //Load all events related to tag Id and add them to events
                string selectSql = @"SELECT * FROM Event WHERE tagId = @tagId";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@tagId", tagId);
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
                            events.Add(@event);
                        }
                    }
                }

                //Load all user Events and add them to eventIds
                string selectSql1 = "SELECT * FROM UserEvents WHERE userId=@userId";
                using (SqlCommand command = new SqlCommand(selectSql1, con))
                {
                    command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            eventIds.Add(Guid.Parse(reader.GetString(reader.GetOrdinal("eventId"))));
                        }
                    }
                }
            }

            //Loop over all the events that are loaded for the clicked tag
            int heightCount = 0;
            int widthCount = 0;
            foreach (var Event in events)
            {
                //compare if the eventId of the current event is the same as one of the booked events and if so then set eventBooked to true
                bool eventBooked = false;
                foreach (var eventId in eventIds)
                {
                    if (eventId == Event.eventId) eventBooked = true;
                }

                //Create a new instance of the CC_DisplayEventCard custom control and assign the appropriate details to the exposed properties
                var eventDisplayCard = new CC_DisplayEventCard()
                {
                    EventId = Event.eventId.ToString(),
                    TagId = Event.tagId.ToString(),
                    EventName = Event.eventName,
                    EventDate = Event.eventDate.ToString("dd/MM/yyyy"),
                    EventDay = Event.eventDate.ToString("dddd"),
                    EventTime = "Starting Time: " + Event.eventDate.ToString("t"),
                    BookEventClick = (s, eventArg) =>
                    {
                        //Redirects the user to events page so they can book the event if they say yes to the prompt below
                        DialogResult result = MessageBox.Show("You are about to be redirected to the Events page. Do you want to continue?",
                                              "Redirect",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Information
                        );

                        if (result == DialogResult.Yes) eventsHomePageTabBtn.PerformClick();
                        return;
                    }
                };

                if (eventBooked)
                {
                    //If this event is already booked by the user then block the user from rebooking it and chnage color and text of the button
                    eventDisplayCard.BookEventButtonText = "Booked";
                    eventDisplayCard.BookEventButtonBackColor = Color.Silver;
                    eventDisplayCard.BookEventButtonEnabled = false;
                }

                //Add control to the eventSearchPanel
                eventSearchPanel.Controls.Add(eventDisplayCard);

                //Modify the location of the control that has been added to the eventBookingPanel so they do not overlap one another
                // Modifies the width and height of the card
                eventDisplayCard.Location = new Point(widthCount * eventDisplayCard.Size.Width, heightCount * eventDisplayCard.Size.Height);

                // Adds gap (width) between cards
                eventDisplayCard.Location = new Point(eventDisplayCard.Location.X + (widthCount * 20), eventDisplayCard.Location.Y);

                // Adds gap (height) between cards
                if (heightCount > 0) eventDisplayCard.Location = new Point(eventDisplayCard.Location.X, eventDisplayCard.Location.Y + (heightCount * 20));

                if (widthCount == 1)
                {
                    heightCount++;
                    widthCount = -1;
                }
                widthCount++;
            }
        }

        //This fucntion assigns an IntrestTag to the current user
        public void InsertIntrestTagToUser(Guid tagId)
        {
            // Check if tagId already in UserTag table
            bool tagIdFound = false;
            //Access the connection string from the App.config and open a connection with the database
            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectSql = @"SELECT * FROM UserTag WHERE userId=@userId AND tagId=@tagId";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                    command.Parameters.AddWithValue("@tagId", tagId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //If it is then set tagIdFound to true
                            tagIdFound = true;
                        }
                    }
                }

                if (!tagIdFound)
                {
                    //If its not found then add new record to UserTag for the current user
                    string insertSql = "INSERT INTO UserTag (userId, tagId) VALUES (@userId, @tagId)";
                    using (SqlCommand command = new SqlCommand(insertSql, con))
                    {
                        command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                        command.Parameters.AddWithValue("@tagId", tagId);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        //This fucntion loads data for the home page pannels
        public void LoadHomePanelData()
        {
            //Clear the search bar and eventSearchPanel for new data 
            searchBarTxt.Text = "";
            eventSearchPanel.Controls.Clear();

            //Create a list of a tuple that stores UserTag as item1 and string as item2 to load the usertag and the tagname already assigned to the current user
            List<Tuple<UserTag, string>> UserTagAndNameList = new List<Tuple<UserTag, string>>();

            //Access the connection string from the App.config and open a connection with the database
            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //This query SELECTS ut.userId, ut.tagId, ut.userTagCreationDate, it.tagId, it.tagName from the UserTag and IntrestTag by LEFT joining the 2 tables
                //WHERE ut.userId is the same as current userId and ORDER the data by ut.userTagCreationDate
                string selectSql = @"SELECT ut.userId, ut.tagId, ut.userTagCreationDate, it.tagId, it.tagName 
                                     FROM UserTag ut
                                     LEFT JOIN IntrestTag it ON ut.tagId = it.tagId 
                                     WHERE ut.userId=@userId   
                                     ORDER BY ut.userTagCreationDate";

                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Create a new instance of the UserTag class and load it with data from the DB
                            UserTag userTag = new UserTag()
                            {
                                userId = Guid.Parse(reader.GetString(reader.GetOrdinal("userId"))),
                                tagId = Guid.Parse(reader.GetString(reader.GetOrdinal("tagId"))),
                                userTagCreationDate = reader.GetDateTime(reader.GetOrdinal("userTagCreationDate"))
                            };
                            string tagName = reader.GetString(reader.GetOrdinal("tagName"));    //Tag name

                            //Add it to the tuple list we created above
                            UserTagAndNameList.Add(new Tuple<UserTag, string>(userTag, tagName));
                        }
                    }
                }
            }

            //clearn the text inside of userTagTxt
            userTagTxt.Text = "";
            if (UserTagAndNameList.Count > 0)
            {
                //Make a new isntance of the StringBuilder class in sb
                StringBuilder sb = new StringBuilder();

                //Loop over the tuple list we created above 'UserTagAndNameList'
                foreach (var userTagAndName in UserTagAndNameList)
                {
                    //Extract Item1 to userTag and Item2 to tagName
                    var userTag = userTagAndName.Item1 as UserTag;
                    string tagName = userTagAndName.Item2 as string;

                    //Add to the string builder instance the new formated string with the info from the DB
                    sb.AppendLine($"{UserSession.User.username} was interested in {tagName} on the {userTag.userTagCreationDate.ToString("dd/MM/yyyy")}, at {userTag.userTagCreationDate.ToString("t")}.");
                }

                //Get the finished version of the string we built using the foreach loop and set it as the text for userTagTxt
                userTagTxt.Text = sb.ToString();
            }
            else userTagTxt.Text = "You have no interests as of now. Interact more on the app to get interest tags.";   //Or set this text if not UserTagAndNameList.count is 0

            //Loop over all the IntrestTags that are loaded at login in UserSession.IntrestTagList
            int heightCount = 0;
            bool bAlreadyAssigned = false;
            foreach (var intrestTag in UserSession.IntrestTagList)
            {
                //compare if the tagId of the current interest tag is the same as one of the alreay assigned intrest tags and if so then set bAlreadyAssigned to true
                foreach (var userTagAndName in UserTagAndNameList)
                {
                    if (intrestTag.tagId == userTagAndName.Item1.tagId)
                    {
                        bAlreadyAssigned = true;
                    }
                }

                //Create a new instance of the CC_HomeInterestTagButton custom control and assign the appropriate details to the exposed properties
                var homeIntrestTagButtonControl = new CC_HomeInterestTagButton()
                {
                    TagId = intrestTag.tagId.ToString(),
                    IntrestTagButtonText = intrestTag.tagName,
                };

                if (bAlreadyAssigned)
                {
                    //If tag already assigned just load events related to the tag button clicked by the user into the eventSearchPanel
                    homeIntrestTagButtonControl.IntrestTagButtonClick = (s, e) =>
                    {
                        LoadClickedIntrestTagEvents_IntoEventSearchPanel(intrestTag.tagId);
                    };
                }
                else
                {
                    //If tag han't been assigned load events related to the tag button clicked by the user into the eventSearchPanel then assign the IntrestTag to the current user
                    homeIntrestTagButtonControl.IntrestTagButtonClick = (s, e) =>
                    {
                        LoadClickedIntrestTagEvents_IntoEventSearchPanel(intrestTag.tagId);
                        InsertIntrestTagToUser(intrestTag.tagId);
                    };
                }

                //Add the contol to homeInterestTagButtonPanel, modify the location of the contol after adding it to the panel
                homeInterestTagButtonPanel.Controls.Add(homeIntrestTagButtonControl);
                homeIntrestTagButtonControl.Location = new Point(homeIntrestTagButtonControl.Location.X, homeIntrestTagButtonControl.Location.Y + (heightCount * 30));
                heightCount++;
                bAlreadyAssigned = false;
            }

            List<Guid> bookedEventIds = new List<Guid>();
            List<Event> userIntrestedEvents = new List<Event>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                //Load already booked events to bookedEventIds
                string selectSql1 = "SELECT * FROM UserEvents WHERE userId=@userId";
                using (SqlCommand command = new SqlCommand(selectSql1, con))
                {
                    command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookedEventIds.Add(Guid.Parse(reader.GetString(reader.GetOrdinal("eventId"))));
                        }
                    }
                }

                //Loop over the users interest tags
                foreach (var userTagAndName in UserTagAndNameList)
                {
                    //Load all the events the user may be interested into 
                    string selectSql = @"SELECT * FROM Event WHERE tagId=@tagId";
                    using (SqlCommand command = new SqlCommand(selectSql, con))
                    {
                        command.Parameters.AddWithValue("@tagId", userTagAndName.Item1.tagId);
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

                                userIntrestedEvents.Add(@event);
                            }
                        }
                    }
                }
            }

            //Clear recommendedEventsPanel for new controls
            recommendedEventsPanel.Controls.Clear();

            // Load control for all userIntrestedEvents into recommendedEventsPanel
            heightCount = 0;
            int widthCount = 0;
            foreach (var Event in userIntrestedEvents)
            {
                //Comapre if eventId of userIntrestedEvents is one of the ids in bookedEventIds if it is then set eventBooked to true
                bool eventBooked = false;
                foreach (var eventId in bookedEventIds)
                {
                    if (eventId == Event.eventId) eventBooked = true;
                }

                //Create CC_DisplayEventCard as a new control and asign the correct details to exposed properties 
                var eventDisplayCard = new CC_DisplayEventCard()
                {
                    EventId = Event.eventId.ToString(),
                    TagId = Event.tagId.ToString(),
                    EventName = Event.eventName,
                    EventDate = Event.eventDate.ToString("dd/MM/yyyy"),
                    EventDay = Event.eventDate.ToString("dddd"),
                    EventTime = "Starting Time: " + Event.eventDate.ToString("t"),
                    BookEventClick = (s, eventArg) =>
                    {
                        //Redirects the user to events page so they can book the event if they say yes to the prompt below
                        DialogResult result = MessageBox.Show("You are about to be redirected to the Events page. Do you want to continue?",
                                              "Redirect",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Information
                        );

                        if (result == DialogResult.Yes) eventsHomePageTabBtn.PerformClick();
                        return;
                    }
                };

                if (eventBooked)
                {
                    //If this event is already booked by the user then block the user from rebooking it and chnage color and text of the button
                    eventDisplayCard.BookEventButtonText = "Booked";
                    eventDisplayCard.BookEventButtonBackColor = Color.Silver;
                    eventDisplayCard.BookEventButtonEnabled = false;
                }

                //Add control to recommendedEventsPanel
                recommendedEventsPanel.Controls.Add(eventDisplayCard);

                //Modify the location of the control that has been added to the eventBookingPanel so they do not overlap one another
                // Modifies the width and height of the card
                eventDisplayCard.Location = new Point(widthCount * eventDisplayCard.Size.Width, heightCount * eventDisplayCard.Size.Height);

                // Adds gap (width) between cards
                eventDisplayCard.Location = new Point(eventDisplayCard.Location.X + (widthCount * 20), eventDisplayCard.Location.Y);

                // Adds gap (height) between cards
                if (heightCount > 0) eventDisplayCard.Location = new Point(eventDisplayCard.Location.X, eventDisplayCard.Location.Y + (heightCount * 20));

                if (widthCount == 0)
                {
                    heightCount++;
                    widthCount = -1;
                }
                widthCount++;
            }
        }


        private void searchBarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            eventSearchPanel.Controls.Clear();
            string searchText = searchBarTxt.Text;

            if (searchText.Length <= 0) return;

            List<Guid> bookedEventIds = new List<Guid>();
            List<Event> eventList = new List<Event>();

            Data data = new Data();
            string connectionString = data.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string selectSql = "SELECT * FROM UserEvents WHERE userId=@userId";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookedEventIds.Add(Guid.Parse(reader.GetString(reader.GetOrdinal("eventId"))));
                        }
                    }
                }

                string selectSql1 = @"SELECT * FROM Event WHERE LOWER(eventName) LIKE LOWER(@searchText) + '%' ORDER BY eventDate;";

                using (SqlCommand command = new SqlCommand(selectSql1, con))
                {
                    command.Parameters.AddWithValue("@searchText", searchText);

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
                    bool eventBooked = false;
                    foreach (var eventId in bookedEventIds)
                    {
                        if (eventId == Event.eventId) eventBooked = true;
                    }

                    var eventDisplayCard = new CC_DisplayEventCard()
                    {
                        EventId = Event.eventId.ToString(),
                        TagId = Event.tagId.ToString(),
                        EventName = Event.eventName,
                        EventDate = Event.eventDate.ToString("dd/MM/yyyy"),
                        EventDay = Event.eventDate.ToString("dddd"),
                        EventTime = "Starting Time: " + Event.eventDate.ToString("t"),
                        BookEventClick = (s, eventArg) =>
                        {
                            DialogResult result = MessageBox.Show("You are about to be redirected to the Events page. Do you want to continue?",
                                                  "Redirect",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Information
                            );

                            if (result == DialogResult.Yes) eventsHomePageTabBtn.PerformClick();
                            return;
                        }
                    };

                    if (eventBooked)
                    {
                        eventDisplayCard.BookEventButtonText = "Booked";
                        eventDisplayCard.BookEventButtonBackColor = Color.Silver;
                        eventDisplayCard.BookEventButtonEnabled = false;
                    }

                    eventSearchPanel.Controls.Add(eventDisplayCard);

                    //Modify the location of the control that has been added to the eventBookingPanel so they do not overlap one another
                    // Modifies the width and height of the card
                    eventDisplayCard.Location = new Point(widthCount * eventDisplayCard.Size.Width, heightCount * eventDisplayCard.Size.Height);

                    // Adds gap (width) between cards
                    eventDisplayCard.Location = new Point(eventDisplayCard.Location.X + (widthCount * 20), eventDisplayCard.Location.Y);

                    // Adds gap (height) between cards
                    if (heightCount > 0) eventDisplayCard.Location = new Point(eventDisplayCard.Location.X, eventDisplayCard.Location.Y + (heightCount * 20));

                    if (widthCount == 1)
                    {
                        heightCount++;
                        widthCount = -1;
                    }
                    widthCount++;
                }
            }
        }

        private void homeDashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            homeDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            homePagePanel.BringToFront();
            Homepage.ActiveForm.Text = "Home Page";

            LoadHomePanelData();
        }

        private void profileDashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            profileDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            profilePagePanel.BringToFront();
            Homepage.ActiveForm.Text = "Profile Page";

            if (UserSession.VisitorLogs.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var visitorLog in UserSession.VisitorLogs)
                {
                    sb.AppendLine($"{UserSession.User.username} visited on the {visitorLog.visitDate.ToString("dd/MM/yyyy")}, at {visitorLog.visitDate.ToString("t")}.");
                }
                visitorLogTxt.Text = sb.ToString();
            }
            else visitorLogTxt.Text = "You have not made any visits to Together Culture as of now.";

            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;

            // Load Username and Email of current user into field
            usernameTxt.Text = UserSession.User.username;
            emailTxt.Text = UserSession.User.email;

            if (!UserSession.User.bIsMember)
            {
                // Check if the user has already made a request to become a member
                bool bRequestMade = false;
                DateTime requestDateTime = DateTime.Now;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string selectSql = "SELECT * FROM AdminRequests WHERE userId=@userId";
                    using (SqlCommand command = new SqlCommand(selectSql, con))
                    {
                        command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                requestDateTime = reader.GetDateTime(reader.GetOrdinal("requestTime"));
                                bRequestMade = true;
                            }
                        }
                    }
                    con.Close();
                }

                if (!bRequestMade)
                {
                    postRequestPanel.Hide();
                    preMemberPanel.Show();
                    preMemberPanel.BringToFront();
                }
                else
                {
                    requestDateLbl.Text = "Request Date: " + requestDateTime.ToString("dd/MMMM/yyyyy");
                    preMemberPanel.Hide();
                    postRequestPanel.Show();
                    postRequestPanel.BringToFront();
                }
                updateUserProfilePanel.BringToFront();
                return;
            }

            // Load MemberKeyIntrest
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string selectSql = "SELECT m.memberId, m.intrestId, m.memberKeyIntrestDate, k.intrestId, k.keyIntrestName FROM MemberKeyIntrest AS m LEFT JOIN KeyIntrest AS k ON m.intrestId = k.intrestId WHERE m.memberId = @memberId";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@memberId", UserSession.Member.memberId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MemberKeyIntrest memberKeyIntrest = new MemberKeyIntrest()
                            {
                                memberId = Guid.Parse(reader.GetString(reader.GetOrdinal("memberId"))),
                                intrestId = Guid.Parse(reader.GetString(reader.GetOrdinal("intrestId"))),
                                keyIntrestName = reader.IsDBNull(reader.GetOrdinal("keyIntrestName")) ? null : reader.GetString(reader.GetOrdinal("keyIntrestName")),
                                memberKeyIntrestDate = reader.GetDateTime(reader.GetOrdinal("memberKeyIntrestDate"))
                            };

                            UserSession.MemberKeyIntrest = memberKeyIntrest;
                        }
                    }
                }
                con.Close();
            }

            if (UserSession.MemberKeyIntrest != null) KeyInterest_CheckedChanged(UserSession.MemberKeyIntrest.keyIntrestName);

            postRequestPanel.Hide();
            preMemberPanel.Hide();
            memberProfilePanel.BringToFront();
            updateUserProfilePanel.BringToFront();
        }

        private void benefitsDashboardBtn_Click(object sender, EventArgs e)
        {
            if (!UserSession.User.bIsMember)
            {
                DialogResult result = MessageBox.Show(
                    "This is a members-only area. Would you like to view available memberships?",
                    "Membership Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes) membershipPageTabBtn.PerformClick();
                return;
            }

            DashboardBtn_BackColorReset();
            benefitsDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            benefitsPagePanel.BringToFront();
            Homepage.ActiveForm.Text = "Active Benefits Page";

            StringBuilder usedBenefitsSB = new StringBuilder();
            StringBuilder unusedBenefitsSB = new StringBuilder();
            foreach (MemberBenefits memberBenefit in UserSession.SubscribedMemberBenefits)
            {
                bool usedBenefit = false;
                foreach (UsedMemberBenefits usedMemberBenefit in UserSession.UsedMemberBenefits)
                {
                    if (memberBenefit.memberBenefitsId == usedMemberBenefit.memberBenefitsId)
                    {
                        usedBenefitsSB.AppendLine(memberBenefit.benefitsDescription);
                        usedBenefit = true;
                    }
                }
                if (!usedBenefit) unusedBenefitsSB.AppendLine(memberBenefit.benefitsDescription);
            }

            unusedBenefitsTxtBox.Text = unusedBenefitsSB.ToString();
            if (UserSession.UsedMemberBenefits.Count > 0) usedBenefitsTxtBox.Text = usedBenefitsSB.ToString();
            else usedBenefitsTxtBox.Text = "No benefits have been used so far.";
        }

        private void digitalConnectionDashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardBtn_BackColorReset();
            digitalConnectionDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            digitalConnectionPanel.BringToFront();
            Homepage.ActiveForm.Text = "Digital Connection Page";
        }
        public void LoadChatsToChatPanel()
        {
            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;
            List<Tuple<ChatLog, string>> chatLogs = new List<Tuple<ChatLog, string>>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string selectSql = "SELECT TOP 50 c.chatId, c.userId, c.chatMessage, c.chatDateTime, u.userId, u.username " +
                                   "FROM ChatLogs c " +
                                   "LEFT JOIN Users u ON c.userId = u.userId " +
                                   "ORDER BY c.chatDateTime";

                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChatLog chatLog = new ChatLog()
                            {
                                chatId = Guid.Parse(reader.GetString(reader.GetOrdinal("chatId"))),
                                userId = Guid.Parse(reader.GetString(reader.GetOrdinal("userId"))),
                                chatMessage = reader.GetString(reader.GetOrdinal("chatMessage")),
                                chatDateTime = reader.GetDateTime(reader.GetOrdinal("chatDateTime")),
                            };

                            string username = reader.GetString(reader.GetOrdinal("username"));
                            chatLogs.Add(new Tuple<ChatLog, string>(chatLog, username));
                        }
                    }
                }
            }

            if (chatLogs.Count > 0)
            {
                int i = 0;
                int totalLogs = chatLogs.Count;
                CC_DisplayChatLogCard lastChatControl = null;
                foreach (var chatLog in chatLogs)
                {
                    ChatLog chat = chatLog.Item1 as ChatLog;
                    string username = chatLog.Item2 as string;

                    var chatDisplayCardControl = new CC_DisplayChatLogCard()
                    {
                        UsernameAndDateText = username + " - (" + chat.chatDateTime.ToString("dd/MM/yyyy") + ")",
                        ChatMessageText = chat.chatMessage
                    };

                    chatMessagesPanel.Controls.Add(chatDisplayCardControl);

                    if (chatMessagesPanel.Controls.Count > 1)
                    {
                        chatDisplayCardControl.Location = new Point(0, i * chatDisplayCardControl.Size.Height);
                    }
                    else
                    {
                        chatDisplayCardControl.Location = new Point(0, 0);
                    }

                    if (i == (totalLogs - 1)) lastChatControl = chatDisplayCardControl;
                    i++;
                }

                chatMessagesPanel.ScrollControlIntoView(lastChatControl);
            }
        }

        private void onlineMembersAreadDashboardBtn_Click(object sender, EventArgs e)
        {
            chatMessagesPanel.Controls.Clear();
            if (!UserSession.User.bIsMember)
            {
                DialogResult result = MessageBox.Show(
                    "This is a members-only area. Would you like to view available memberships?",
                    "Membership Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes) membershipPageTabBtn.PerformClick();
                return;
            }

            DashboardBtn_BackColorReset();
            onlineMembersAreadDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            onlineMembersAreaPanel.BringToFront();
            Homepage.ActiveForm.Text = "Online Members Area Page";

            LoadChatsToChatPanel();
        }

        private void sendMsgBtn_Click(object sender, EventArgs e)
        {
            // Insert Chat Record into ChatLogs
            if (UserSession.User.bIsMember)
            {
                string chatText = chatTextBox.Text;
                Guid chatId = Guid.NewGuid();
                Data dataCls = new Data();
                string connectionString = dataCls.ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string insertSql = "INSERT INTO ChatLogs (chatId, userId, chatMessage) VALUES (@chatId, @userId, @chatMessage)";
                    using (SqlCommand command = new SqlCommand(insertSql, con))
                    {
                        command.Parameters.AddWithValue("@chatId", chatId);
                        command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                        command.Parameters.AddWithValue("@chatMessage", chatText);
                        command.ExecuteNonQuery();
                    }
                }
            }

            chatTextBox.Text = "";
            onlineMembersAreadDashboardBtn.PerformClick();
        }

        public void BookDigitalContentModule(Guid digitalContentModuleId, string moduleName)
        {
            // Book the DigitalContentModule for the current user
            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string insertSql = "INSERT INTO UserDigitalContentModule (userId, digitalContentModuleId) VALUES (@userId, @digitalContentModuleId)";
                using (SqlCommand command = new SqlCommand(insertSql, con))
                {
                    command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                    command.Parameters.AddWithValue("@digitalContentModuleId", digitalContentModuleId);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("You have successfully booked " + moduleName + "!", "Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            digitalContentDashboardBtn.PerformClick();
        }

        private void digitalContentDashboardBtn_Click(object sender, EventArgs e)
        {
            digitalContentDataPanel.Controls.Clear();
            if (!UserSession.User.bIsMember)
            {
                DialogResult result = MessageBox.Show(
                    "This is a members-only area. Would you like to view available memberships?",
                    "Membership Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes) membershipPageTabBtn.PerformClick();
                return;
            }

            DashboardBtn_BackColorReset();
            digitalContentDashboardBtn.BackColor = Color.FromArgb(128, 255, 128);
            digitalContentPanel.BringToFront();
            Homepage.ActiveForm.Text = "Digital Content Page";

            List<Tuple<Guid, DateTime>> bookedDigitalContentModules = new List<Tuple<Guid, DateTime>>();
            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string selectSql = "SELECT * FROM UserDigitalContentModule WHERE userId=@userId";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid digitalContentModuleId = Guid.Parse(reader.GetString(reader.GetOrdinal("digitalContentModuleId")));
                            DateTime moduleDateBooked = reader.GetDateTime(reader.GetOrdinal("moduleDateBooked"));

                            Tuple<Guid, DateTime> moduleInfo = Tuple.Create(digitalContentModuleId, moduleDateBooked);
                            bookedDigitalContentModules.Add(moduleInfo);
                        }
                    }
                }
            }

            int heightCount = 0;
            int widthCount = 0;
            foreach (var digitalContentModule in UserSession.DigitalContentModules)
            {
                DateTime moduleDateTime = DateTime.Now;
                bool bookedModule = false;
                foreach (var bookedDigitalContentModule in bookedDigitalContentModules)
                {
                    var bookedigitalModuleId = bookedDigitalContentModule.Item1;

                    if (bookedigitalModuleId == digitalContentModule.digitalContentModuleId)
                    {
                        moduleDateTime = bookedDigitalContentModule.Item2;
                        bookedModule = true;
                    }
                }

                var moduleDisplayCard = new CC_DisplayDigtialContentModule()
                {
                    ModuleName = digitalContentModule.moduleName,
                    BookModuleButtonClick = (s, eventArg) =>
                    {
                        BookDigitalContentModule(digitalContentModule.digitalContentModuleId, digitalContentModule.moduleName);
                    }
                };

                if (bookedModule)
                {
                    moduleDisplayCard.ModuleDateVisible = true;
                    moduleDisplayCard.ModuleDate = moduleDateTime.ToString("dd/MM/yy");
                    moduleDisplayCard.Enabled = false;
                    moduleDisplayCard.BookModuleButtonText = "Module Booked";
                    moduleDisplayCard.BookModuleButtonBackColor = Color.Silver;
                }
                else moduleDisplayCard.ModuleDateVisible = false;

                digitalContentDataPanel.Controls.Add(moduleDisplayCard);

                //Modify the location of the control that has been added to the eventBookingPanel so they do not overlap one another
                // Modifies the width and height of the card
                moduleDisplayCard.Location = new Point(widthCount * moduleDisplayCard.Size.Width, heightCount * moduleDisplayCard.Size.Height);

                // Adds gap (width) between cards
                moduleDisplayCard.Location = new Point(moduleDisplayCard.Location.X + (widthCount * 20), moduleDisplayCard.Location.Y);

                // Adds gap (height) between cards
                if (heightCount > 0) moduleDisplayCard.Location = new Point(moduleDisplayCard.Location.X, moduleDisplayCard.Location.Y + (heightCount * 20));

                if (widthCount == 2)
                {
                    heightCount++;
                    widthCount = -1;
                }
                widthCount++;
            }
        }

        private void membershipDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMembershipTypeName = membershipDropBox.Text;
            var selectedMembership = UserSession.MembershipTypes.FirstOrDefault(mt => mt.typeName == selectedMembershipTypeName);

            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;
            List<string> memberBenefits = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<Guid> memberBenefitsIdList = new List<Guid>();
                con.Open();
                string selectSql = "SELECT memberBenefitsId FROM MembershipTypeBenefits WHERE membershipTypeId=@membershipTypeId";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@membershipTypeId", selectedMembership.membershipTypeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            memberBenefitsIdList.Add(Guid.Parse(reader.GetString(reader.GetOrdinal("memberBenefitsId"))));
                        }
                    }
                }

                string selectSql1 = "SELECT benefitsDescription FROM MemberBenefits WHERE memberBenefitsId=@memberBenefitsId";
                foreach (Guid memberBenefitsId in memberBenefitsIdList)
                {
                    using (SqlCommand command1 = new SqlCommand(selectSql1, con))
                    {
                        command1.Parameters.AddWithValue("@memberBenefitsId", memberBenefitsId);
                        using (SqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                memberBenefits.Add(reader.GetString(reader.GetOrdinal("benefitsDescription")));
                            }
                        }
                    }
                }
            }

            membershipDescriptionTxtBox.Text = "Membership Name: " + selectedMembership.typeName + "\nDescription: " + selectedMembership.description + "\nCost: £" +
            selectedMembership.cost.ToString() + "\nJoining Fee: £" + selectedMembership.joiningFee.ToString() + "\nDuration: " + selectedMembership.duration;

            StringBuilder sb = new StringBuilder();
            foreach (string memberBenefit in memberBenefits)
            {
                sb.AppendLine(memberBenefit);
            }

            membershipBenefitsTxtBox.Text = sb.ToString();
        }

        private void becomeAMemberBtn_Click(object sender, EventArgs e)
        {
            string selectedMembershipTypeName = membershipDropBox.Text;

            if (selectedMembershipTypeName == "Select Membership...")
            {
                MessageBox.Show("Please select a membership. Try again.");
                return;
            }

            Guid memberId = Guid.NewGuid();
            Guid currentUserId = UserSession.User.userId;
            var selectedMembership = UserSession.MembershipTypes.FirstOrDefault(mt => mt.typeName == selectedMembershipTypeName);

            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Delete any requests in the AdminRequests table created at signup
                string deleteSql = @"DELETE FROM AdminRequests WHERE userId=@userId";
                using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                {
                    command1.Parameters.AddWithValue("@userId", currentUserId);
                    command1.ExecuteNonQuery();
                }

                // Update Users table for bIsMemeber
                string updateUserSql = "UPDATE Users SET bIsMember=1 WHERE userId=@userId";
                using (SqlCommand command = new SqlCommand(updateUserSql, con))
                {
                    command.Parameters.AddWithValue("@userId", currentUserId);
                    command.ExecuteNonQuery();
                }

                // Add record to Member table
                string insertMemberSql = "INSERT INTO Member (memberId, userId, membershipTypeId) VALUES (@memberId, @userId, @membershipTypeId)";
                using (SqlCommand command = new SqlCommand(insertMemberSql, con))
                {
                    command.Parameters.AddWithValue("@memberId", memberId);
                    command.Parameters.AddWithValue("@userId", currentUserId);
                    command.Parameters.AddWithValue("@membershipTypeId", selectedMembership.membershipTypeId);
                    command.ExecuteNonQuery();
                }

                // Load Active Member Benefits
                List<Guid> memberBenefitsIdList = new List<Guid>();
                string selectSql1 = "SELECT memberBenefitsId FROM MembershipTypeBenefits WHERE membershipTypeId=@membershipTypeId";
                using (SqlCommand command1 = new SqlCommand(selectSql1, con))
                {
                    command1.Parameters.AddWithValue("@membershipTypeId", selectedMembership.membershipTypeId);
                    using (SqlDataReader reader1 = command1.ExecuteReader())
                    {
                        while (reader1.Read())
                        {
                            memberBenefitsIdList.Add(Guid.Parse(reader1.GetString(reader1.GetOrdinal("memberBenefitsId"))));
                        }
                    }
                }

                string selectSql2 = "SELECT * FROM MemberBenefits WHERE memberBenefitsId=@memberBenefitsId";
                foreach (Guid memberBenefitsId in memberBenefitsIdList)
                {
                    using (SqlCommand command1 = new SqlCommand(selectSql2, con))
                    {
                        command1.Parameters.AddWithValue("@memberBenefitsId", memberBenefitsId);
                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                MemberBenefits memberBenefit = new MemberBenefits()
                                {
                                    memberBenefitsId = Guid.Parse(reader1.GetString(reader1.GetOrdinal("memberBenefitsId"))),
                                    benefitsDescription = reader1.GetString(reader1.GetOrdinal("benefitsDescription"))
                                };

                                UserSession.SubscribedMemberBenefits.Add(memberBenefit);
                            }
                        }
                    }
                }
                con.Close();

                UserSession.User.bIsMember = true;

                UserSession.Member.memberId = memberId;
                UserSession.Member.userId = currentUserId;
                UserSession.Member.membershipTypeId = selectedMembership.membershipTypeId;

                UserSession.ActiveMembership = selectedMembership;

                UserSession.MembershipTypes.Clear();

                MessageBox.Show("You membership has been updated to " + selectedMembership.typeName + "!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            membershipPageTabBtn.PerformClick();
        }

        private void cancleMembershipBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to cancel your memberships?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

            if (result == DialogResult.Yes)
            {
                Guid currentUserId = UserSession.User.userId;
                Data dataCls = new Data();
                string connectionString = dataCls.ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Update Users table for bIsMemeber
                    string updateUserSql = "UPDATE Users SET bIsMember=0 WHERE userId=@userId";
                    using (SqlCommand command = new SqlCommand(updateUserSql, con))
                    {
                        command.Parameters.AddWithValue("@userId", currentUserId);
                        command.ExecuteNonQuery();
                    }

                    // Delete UserDigitalContentModule records
                    string deleteSql3 = @"DELETE FROM UserDigitalContentModule WHERE userId=@userId";
                    using (SqlCommand command1 = new SqlCommand(deleteSql3, con))
                    {
                        command1.Parameters.AddWithValue("@userId", UserSession.User.userId);
                        command1.ExecuteNonQuery();
                    }

                    // Delete UsedMemberBenefits records as member table has a FK restraint based of this table
                    string deleteSql1 = @"DELETE FROM UsedMemberBenefits WHERE memberId=@memberId";
                    using (SqlCommand command1 = new SqlCommand(deleteSql1, con))
                    {
                        command1.Parameters.AddWithValue("@memberId", UserSession.Member.memberId);
                        command1.ExecuteNonQuery();
                    }

                    // Delete MemberKeyIntrest records as member table has a FK restraint based of this table
                    string deleteSql2 = @"DELETE FROM MemberKeyIntrest WHERE memberId=@memberId";
                    using (SqlCommand command1 = new SqlCommand(deleteSql2, con))
                    {
                        command1.Parameters.AddWithValue("@memberId", UserSession.Member.memberId);
                        command1.ExecuteNonQuery();
                    }

                    // Delete Member record
                    string deleteSql = @"DELETE FROM Member WHERE userId=@userId";
                    using (SqlCommand command1 = new SqlCommand(deleteSql, con))
                    {
                        command1.Parameters.AddWithValue("@userId", currentUserId);
                        command1.ExecuteNonQuery();
                    }
                }

                UserSession.User.bIsMember = false;
                UserSession.Member = new Member();
                UserSession.ActiveMembership = new MembershipType();
                UserSession.MemberKeyIntrest = new MemberKeyIntrest();
                UserSession.SubscribedMemberBenefits.Clear();
                UserSession.UsedMemberBenefits.Clear();

                membershipPageTabBtn.PerformClick();
            }
            return;
        }

        private void requestMembershipBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to submit a membership request?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                Data dataCls = new Data();
                string connectionString = dataCls.ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    Guid adminRequestId = Guid.NewGuid();
                    string insertRequestSql = "INSERT INTO AdminRequests (adminRequestId, userId, requestDescription, requestTime) VALUES (@adminRequestId, @userId, @requestDescription, @requestTime)";
                    using (SqlCommand command = new SqlCommand(insertRequestSql, con))
                    {
                        command.Parameters.AddWithValue("@adminRequestId", adminRequestId);
                        command.Parameters.AddWithValue("@userId", UserSession.User.userId);
                        command.Parameters.AddWithValue("@requestDescription", "Request to become a member.");
                        command.Parameters.AddWithValue("@requestTime", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }

                profileDashboardBtn.PerformClick();
            }
            return;
        }

        private void updateUserProfileBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to update your user infromation?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                string username = usernameTxt.Text;
                string email = emailTxt.Text;

                #region User Validations
                if (username == "" || email == "")
                {
                    MessageBox.Show("Please fill in all the feilds.", "Invalid Inputs");
                    return;
                }
                if (username.Length < 3 || username.Length > 20 || username.StartsWith("_") || username.EndsWith("_"))
                {
                    MessageBox.Show("Please enter a username that is between 3 and 20 characters long. The username cannot start or end with an underscore.", "Invalid Username");
                    return;
                }
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Invalid email address. Please enter a valid email address.", "Invalid Email");
                    return;
                }
                #endregion

                if (username == UserSession.User.username && email == UserSession.User.email)
                {
                    MessageBox.Show("User is already up to date. Nothing to modify.", "Up to date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Data data = new Data();
                string connectionString = data.ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string updateSql = @"UPDATE Users SET username=@username, email=@email WHERE userId=@userId";

                    using (SqlCommand command = new SqlCommand(updateSql, con))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@userId", UserSession.User.userId);

                        command.ExecuteNonQuery();
                    }
                }

                // Update current session
                UserSession.User.username = username;
                UserSession.User.email = email;

                MessageBox.Show("User has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loggedInLbl.Text = username;
                profileDashboardBtn.PerformClick();
            }
        }

        public void KeyInterest_CheckedChanged(string interestName)
        {
            caringCheckBox.Checked = false;
            sharingCheckBox.Checked = false;
            workingCheckBox.Checked = false;
            learningCheckBox.Checked = false;
            happeningCheckBox.Checked = false;

            switch (interestName)
            {
                case "Caring":
                    caringCheckBox.Checked = true;
                    break;
                case "Sharing":
                    sharingCheckBox.Checked = true;
                    break;
                case "Working":
                    workingCheckBox.Checked = true;
                    break;
                case "Learning":
                    learningCheckBox.Checked = true;
                    break;
                case "Happening":
                    happeningCheckBox.Checked = true;
                    break;
            }
        }

        private void caringCheckBox_Click(object sender, EventArgs e)
        {
            KeyInterest_CheckedChanged("Caring");
        }

        private void sharingCheckBox_Click(object sender, EventArgs e)
        {
            KeyInterest_CheckedChanged("Sharing");
        }

        private void workingCheckBox_Click(object sender, EventArgs e)
        {
            KeyInterest_CheckedChanged("Working");
        }

        private void learningCheckBox_Click(object sender, EventArgs e)
        {
            KeyInterest_CheckedChanged("Learning");
        }

        private void happeningCheckBox_Click(object sender, EventArgs e)
        {
            KeyInterest_CheckedChanged("Happening");
        }

        private void updateKeyIntrestBtn_Click(object sender, EventArgs e)
        {
            var checkboxes = new List<(bool IsChecked, string Text)>
            {
                (caringCheckBox.Checked, caringCheckBox.Text),
                (sharingCheckBox.Checked, sharingCheckBox.Text),
                (workingCheckBox.Checked, workingCheckBox.Text),
                (learningCheckBox.Checked, learningCheckBox.Text),
                (happeningCheckBox.Checked, happeningCheckBox.Text)
            };

            string currentKeyInterestName = UserSession.MemberKeyIntrest?.keyIntrestName;
            string newKeyInterestName = null;

            // Find a matching checkbox for the current key interest
            var currentMatch = checkboxes.FirstOrDefault(cb => cb.IsChecked && cb.Text == currentKeyInterestName);
            if (currentMatch != default)
            {
                MessageBox.Show("Key Interest is already up to date. Nothing to modify.", "Info Up to Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Find the new key interest name from the checked checkbox
            var newMatch = checkboxes.FirstOrDefault(cb => cb.IsChecked);
            if (newMatch == default)
            {
                MessageBox.Show("Please select a Key Interest to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            newKeyInterestName = newMatch.Text;
            Data dataCls = new Data();
            string connectionString = dataCls.ConnectionString;

            // Delete Current Record (if it exists)
            if (UserSession.MemberKeyIntrest != null)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string deleteSql = "DELETE FROM MemberKeyIntrest WHERE intrestId = @intrestId";
                    using (SqlCommand command = new SqlCommand(deleteSql, con))
                    {
                        command.Parameters.AddWithValue("@intrestId", UserSession.MemberKeyIntrest.intrestId);
                        command.ExecuteNonQuery();
                    }
                }
            }

            Guid intrestId = Guid.Empty;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Retrieve the intrestId for the new key interest
                string selectSql = "SELECT intrestId FROM KeyIntrest WHERE keyIntrestName = @keyIntrestName";
                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@keyIntrestName", newKeyInterestName);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            intrestId = Guid.Parse(reader.GetString(reader.GetOrdinal("intrestId")));
                        }
                    }
                }

                // Insert the new key intrest record
                string insertSql = "INSERT INTO MemberKeyIntrest (memberId, intrestId) VALUES (@memberId, @intrestId)";
                using (SqlCommand command = new SqlCommand(insertSql, con))
                {
                    command.Parameters.AddWithValue("@memberId", UserSession.Member.memberId);
                    command.Parameters.AddWithValue("@intrestId", intrestId);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Key Interest has been updated.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            profileDashboardBtn.PerformClick();
        }
    }
}
