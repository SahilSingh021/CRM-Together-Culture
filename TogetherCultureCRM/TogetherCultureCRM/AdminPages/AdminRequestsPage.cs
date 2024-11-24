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
    public partial class AdminRequestsPage : Form
    {
        public AdminRequestsPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            //base.OnLoad(e);

            if (!User.bIsAdmin)
            {
                if (User.username == null)
                {
                    Login login = new Login();
                    login.Show();
                }
                else
                {
                    Homepage homepage = new Homepage();
                    homepage.Show();
                }
                this.Hide();
                return;
            }

            requestPanel.Controls.Clear();

            Data data = new Data();
            string connectionString = data.ConnectionString;
            List<Tuple<AdminRequests, string>> adminRequests = new List<Tuple<AdminRequests, string>>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectSql = "SELECT TOP 20 ar.adminRequestId, ar.userId, ar.requestDescription, ar.requestTime, u.username " +
                    "FROM AdminRequests ar " +
                    "JOIN Users u ON ar.userId = u.userId";

                using (SqlCommand command = new SqlCommand(selectSql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AdminRequests adminRequest = new AdminRequests()
                            {
                                adminRequestId = Guid.Parse(reader.GetString(reader.GetOrdinal("adminRequestId"))),
                                userId = Guid.Parse(reader.GetString(reader.GetOrdinal("userId"))),
                                requestDescription = reader.GetString(reader.GetOrdinal("requestDescription")),
                                requestTime = reader.GetDateTime(reader.GetOrdinal("requestTime"))
                            };

                            string username = reader.GetString(reader.GetOrdinal("username"));
                            adminRequests.Add(new Tuple<AdminRequests, string>(adminRequest, username));
                        }
                    }
                }

                con.Close();
            }

            if (adminRequests.Count > 0)
            {
                noIncommingRequestsLbl.Hide();
                int i = 0;
                foreach (var item in adminRequests)
                {
                    AdminRequests request = item.Item1;
                    string username = item.Item2;

                    var requestControl = new CC_Request();
                    requestControl.UsernameLbl = username + " - [" + request.requestTime.Date.ToString("dd/MM/yy") + "]";
                    requestControl.DescriptionLbl = request.requestDescription;
                    requestControl.AdminRequestIdLbl = request.adminRequestId.ToString();

                    requestPanel.Controls.Add(requestControl);

                    if (requestPanel.Controls.Count > 1)
                    {
                        requestControl.Location = new Point(0, i * requestControl.Size.Height);
                    }
                    else
                    {
                        requestControl.Location = new Point(0, 0);
                    }
                    i++;
                }
            }
            else noIncommingRequestsLbl.Show();
        }
    }
}
