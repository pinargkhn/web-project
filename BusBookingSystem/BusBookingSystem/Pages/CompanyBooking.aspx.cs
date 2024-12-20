using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI;

namespace BusBookingSystem.Pages
{
    public partial class CompanyBooking : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBookings();
            }
        }

        private void LoadBookings()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = @"
                SELECT 
                    b.BookingID, 
                    COALESCE(bs.BusName, 'Unknown') AS BusName, 
                    COALESCE(bs.DepartureLocation, 'Unknown') AS DepartureLocation, 
                    COALESCE(bs.ArrivalLocation, 'Unknown') AS ArrivalLocation, 
                    b.BookingDate, 
                    b.Status
                FROM bookings b
                LEFT JOIN buses bs ON b.BusID = bs.BusID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable bookingsTable = new DataTable();
                        bookingsTable.Load(reader);

                        if (bookingsTable.Rows.Count > 0)
                        {
                            gvBookings.DataSource = bookingsTable;
                            gvBookings.DataBind();
                            lblNoBookings.Visible = false;
                        }
                        else
                        {
                            gvBookings.DataSource = null;
                            gvBookings.DataBind();
                            lblNoBookings.Visible = true;
                        }
                    }
                }
            }
        }
    }
}
