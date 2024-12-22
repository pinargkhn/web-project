using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace BusBookingSystem.Pages
{
    public partial class EditBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bookingId = Request.QueryString["BookingID"];
                if (!string.IsNullOrEmpty(bookingId))
                {
                    LoadBookingDetails(bookingId);
                }
            }
        }

        private void LoadBookingDetails(string bookingId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = "SELECT CustomerID, BusID, BookingDate, Status FROM bookings WHERE BookingID = @BookingID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingID", bookingId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtCustomerID.Text = reader["CustomerID"].ToString();
                            txtBusID.Text = reader["BusID"].ToString();
                            txtBookingDate.Text = DateTime.TryParse(reader["BookingDate"].ToString(), out DateTime date) ? date.ToString("yyyy-MM-ddTHH:mm") : "";
                            txtStatus.Text = reader["Status"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string bookingId = Request.QueryString["BookingID"];
            string customerId = txtCustomerID.Text.Trim();
            string busId = txtBusID.Text.Trim();
            string bookingDate = txtBookingDate.Text.Trim();
            string status = txtStatus.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = @"
                UPDATE bookings 
                SET 
                    CustomerID = @CustomerID, 
                    BusID = @BusID, 
                    BookingDate = @BookingDate, 
                    Status = @Status 
                WHERE BookingID = @BookingID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingID", bookingId);
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
