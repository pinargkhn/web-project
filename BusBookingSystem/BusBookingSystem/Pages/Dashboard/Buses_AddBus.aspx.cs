using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace BusBookingSystem.Pages
{
    public partial class Buses_AddBus : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string busName = txtBusName.Text.Trim();
            string departureLocation = txtDepartureLocation.Text.Trim();
            string arrivalLocation = txtArrivalLocation.Text.Trim();
            string departureTime = txtDepartureTime.Text.Trim();
            int seatsAvailable = int.TryParse(txtSeatsAvailable.Text, out int seats) ? seats : 0;

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string query = @"INSERT INTO buses (BusName, DepartureLocation, ArrivalLocation, DepartureTime, SeatsAvailable)
                             VALUES (@BusName, @DepartureLocation, @ArrivalLocation, @DepartureTime, @SeatsAvailable)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BusName", busName);
                    command.Parameters.AddWithValue("@DepartureLocation", departureLocation);
                    command.Parameters.AddWithValue("@ArrivalLocation", arrivalLocation);
                    command.Parameters.AddWithValue("@DepartureTime", departureTime);
                    command.Parameters.AddWithValue("@SeatsAvailable", seatsAvailable);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Redirect("~/Pages/Dashboard/Buses.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/Buses.aspx");
        }
    }
}
