using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace BusBookingSystem.Pages
{
    public partial class AddBooking : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerID.Text.Trim();
            string busId = txtBusID.Text.Trim();
            string bookingDate = txtBookingDate.Text.Trim();
            string status = txtStatus.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = @"
                INSERT INTO bookings (CustomerID, BusID, BookingDate, Status) 
                VALUES (@CustomerID, @BusID, @BookingDate, @Status)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    command.Parameters.AddWithValue("@BusID", busId);
                    command.Parameters.AddWithValue("@BookingDate", DateTime.TryParse(bookingDate, out DateTime date) ? date : DateTime.Now);
                    command.Parameters.AddWithValue("@Status", status);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Redirect("~/Pages/Dashboard/Bookings.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/Bookings.aspx");
        }
    }
}
