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
                SeedBookings(); // Rastgele verileri ekle
                LoadBookings(); // Veritabanını yükle
            }
        }

        private void SeedBookings()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Rastgele veri eklemek için bir döngü
                for (int i = 1; i <= 10; i++)
                {
                    string insertQuery = @"
                        INSERT INTO bookings (CustomerID, BusID, BookingDate, Status)
                        VALUES (@CustomerID, @BusID, @BookingDate, @Status)";

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        Random random = new Random();
                        int customerId = random.Next(1, 5); // Rastgele CustomerID (1-5 arasında)
                        int busId = random.Next(1, 5); // Rastgele BusID (1-5 arasında)
                        string status = (random.Next(0, 2) == 0) ? "Booked" : "Cancelled"; // Rastgele durum

                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        command.Parameters.AddWithValue("@BusID", busId);
                        command.Parameters.AddWithValue("@BookingDate", DateTime.Now.AddDays(random.Next(-30, 30))); // Rastgele tarih
                        command.Parameters.AddWithValue("@Status", status);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void LoadBookings()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = @"
                SELECT 
                    b.BookingID, 
                    b.CustomerID AS CustomerName, 
                    b.BusID AS BusName, 
                    b.BookingDate, 
                    b.Status
                FROM bookings b";

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
