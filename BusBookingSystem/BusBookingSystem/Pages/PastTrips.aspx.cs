using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingSystem.Pages
{
    public partial class PastTrips : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kullanıcı giriş kontrolü
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("~/Pages/Book.aspx"); // Kullanıcı giriş yapmamışsa yönlendirme
            }

            if (!IsPostBack)
            {
                LoadPastTrips();
            }
        }

        private void LoadPastTrips()
        {
            // Session'dan CustomerID alınır
            int customerId = Convert.ToInt32(Session["CustomerID"]);

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
                LEFT JOIN buses bs ON b.BusID = bs.BusID
                WHERE b.CustomerID = @CustomerID"; // Kullanıcıya ait kayıtları getir

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerId);

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable pastTripsTable = new DataTable();
                        pastTripsTable.Load(reader);

                        if (pastTripsTable.Rows.Count > 0)
                        {
                            gvPastTrips.DataSource = pastTripsTable;
                            gvPastTrips.DataBind();
                            lblNoPastTrips.Visible = false;
                        }
                        else
                        {
                            gvPastTrips.DataSource = null;
                            gvPastTrips.DataBind();
                            lblNoPastTrips.Visible = true;
                        }
                    }
                }
            }
        }

        protected void gvPastTrips_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CancelTrip")
            {
                int bookingId = Convert.ToInt32(e.CommandArgument);
                CancelBooking(bookingId);
            }
        }

        private void CancelBooking(int bookingId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string updateQuery = "UPDATE bookings SET Status = 'Cancelled' WHERE BookingID = @BookingID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@BookingID", bookingId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Refresh the grid after successful update
                        LoadPastTrips();
                    }
                }
            }
        }
    }
}
