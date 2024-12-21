using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace BusBookingSystem.Pages
{
    public partial class AddBus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = "INSERT INTO buses (BusName, DepartureLocation, ArrivalLocation, DepartureTime, SeatsAvailable) VALUES (@BusName, @DepartureLocation, @ArrivalLocation, @DepartureTime, @SeatsAvailable)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BusName", txtBusName.Text);
                    command.Parameters.AddWithValue("@DepartureLocation", txtDeparture.Text);
                    command.Parameters.AddWithValue("@ArrivalLocation", txtArrival.Text);
                    command.Parameters.AddWithValue("@DepartureTime", DateTime.TryParse(txtTime.Text, out DateTime depTime) ? depTime : DateTime.MinValue);
                    command.Parameters.AddWithValue("@SeatsAvailable", int.TryParse(txtSeats.Text, out int seats) ? seats : 0);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Redirect to the Manage Buses page
            Response.Redirect("~/Pages/CompanyBus.aspx");
        }
    }
}
