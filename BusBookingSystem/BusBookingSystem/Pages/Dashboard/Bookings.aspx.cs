using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingSystem.Pages
{
    public partial class Bookings : Page
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
                    BookingID, 
                    CustomerID, 
                    BusID, 
                    BookingDate, 
                    Status 
                FROM bookings";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable bookingsTable = new DataTable();
                        bookingsTable.Load(reader);

                        gvBookings.DataSource = bookingsTable;
                        gvBookings.DataBind();
                    }
                }
            }
        }

        protected void gvBookings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int bookingId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditBooking")
            {
                Response.Redirect($"~/Pages/Dashboard/Bookings_EditBooking.aspx?BookingID={bookingId}");
            }
            else if (e.CommandName == "DeleteBooking")
            {
                DeleteBooking(bookingId);
                LoadBookings();
            }
        }

        protected void btnAddBooking_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/Bookings_AddBooking.aspx");
        }

        private void DeleteBooking(int bookingId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = "DELETE FROM bookings WHERE BookingID = @BookingID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingID", bookingId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
