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
    public partial class AdminViewEventDetailsPage : Form
    {
        public AdminViewEventDetailsPage(Event selectdEvent)
        {
            InitializeComponent();
            _selectdEvent = selectdEvent;
        }

        public AdminViewEventDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Data data = new Data();
            string connectionString = data.ConnectionString;
            List<Tuple<User, string>> userList = new List<Tuple<User, string>>();

            // Load all users that have booked the selected event
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectSql = @"SELECT
                                        ue.userId, ue.eventId, u.userId, u.username, u.password, u.email, u.bIsAdmin, u.bIsBanned, u.bIsMember, m.membershipTypeId, mt.typeName
                                    FROM 
                                        UserEvents ue
                                    LEFT JOIN 
                                        Users u ON ue.userId = u.userId
                                    LEFT JOIN 
                                        Member m ON u.userId = m.userId
                                    LEFT JOIN 
                                        MembershipType mt ON m.membershipTypeId = mt.membershipTypeId
                                    WHERE 
                                        ue.eventId=@eventId";

                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    command.Parameters.AddWithValue("@eventId", _selectdEvent.eventId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User()
                            {
                                userId = Guid.Parse(reader.GetString(reader.GetOrdinal("userId"))),
                                username = reader.GetString(reader.GetOrdinal("username")),
                                password = reader.GetString(reader.GetOrdinal("password")),
                                email = reader.GetString(reader.GetOrdinal("email")),
                                bIsAdmin = reader.GetBoolean(reader.GetOrdinal("bIsAdmin")),
                                bIsBanned = reader.GetBoolean(reader.GetOrdinal("bIsBanned")),
                                bIsMember = reader.GetBoolean(reader.GetOrdinal("bIsMember"))
                            };

                            string membershipName = reader.IsDBNull(reader.GetOrdinal("typeName"))
                                ? ""
                                : reader.GetString(reader.GetOrdinal("typeName"));

                            userList.Add(new Tuple<User, string>(user, membershipName));
                        }
                    }
                }
            }

            totalGuestsLbl.Text = "Total Guests: " + userList.Count;

            if (userList.Count > 0) noEventsLbl.Visible = false;
            else noEventsLbl.Visible = true;

            if (userList.Count > 0)
            {
                int i = 0;
                foreach (var item in userList)
                {
                    var user = item.Item1;
                    var userDisplayCardControl = new CC_DisplayUserCard();
                    userDisplayCardControl.UserIdLbl = user.userId.ToString();
                    userDisplayCardControl.UsernameText = "Username: " + user.username;
                    userDisplayCardControl.PasswordText = user.password;
                    userDisplayCardControl.EmailText = "Email: " + user.email;
                    userDisplayCardControl.IsAdmin = user.bIsAdmin;
                    userDisplayCardControl.IsBanned = user.bIsBanned;
                    userDisplayCardControl.IsMember = user.bIsMember;

                    if (user.bIsMember)
                    {
                        userDisplayCardControl.MembershipText = "Membership: " + item.Item2;
                        userDisplayCardControl.MembershipTextVisible = true;
                    }
                    else userDisplayCardControl.MembershipTextVisible = false;

                    userDisplayCardControl.ManageButtonText = "Booked";
                    userDisplayCardControl.ManageButtonEnabled = false;
                    userDisplayCardControl.ManageButtonColor = Color.Silver;

                    mainPanel.Controls.Add(userDisplayCardControl);

                    if (mainPanel.Controls.Count > 1)
                    {
                        userDisplayCardControl.Location = new Point(0, i * userDisplayCardControl.Size.Height);
                    }
                    else
                    {
                        userDisplayCardControl.Location = new Point(0, 0);
                    }
                    i++;
                }
            }
        }

        private Event _selectdEvent;
    }
}
