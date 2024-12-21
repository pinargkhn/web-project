using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace BusBookingSystem.Pages
{
    public partial class EditBus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string busId = Request.QueryString["BusID"];
                if (!string.IsNullOrEmpty(busId))
                {
                    LoadBusDetails(busId);
                }
            }
        }

        private void LoadBusDetails(string busId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = "SELECT BusName, DepartureLocation, ArrivalLocation, DepartureTime, SeatsAvailable FROM buses WHERE BusID = @BusID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BusID", busId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtBusName.Text = reader["BusName"].ToString();
                            txtDeparture.Text = reader["DepartureLocation"].ToString();
                            txtArrival.Text = reader["ArrivalLocation"].ToString();
                            txtTime.Text = DateTime.TryParse(reader["DepartureTime"].ToString(), out DateTime depTime) ? depTime.ToString("yyyy-MM-ddTHH:mm") : "";
                            txtSeats.Text = reader["SeatsAvailable"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string busId = Request.QueryString["BusID"];
            if (!string.IsNullOrEmpty(busId))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                string query = "UPDATE buses SET BusName = @BusName, DepartureLocation = @DepartureLocation, ArrivalLocation = @ArrivalLocation, DepartureTime = @DepartureTime, SeatsAvailable = @SeatsAvailable WHERE BusID = @BusID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BusName", txtBusName.Text);
                        command.Parameters.AddWithValue("@DepartureLocation", txtDeparture.Text);
                        command.Parameters.AddWithValue("@ArrivalLocation", txtArrival.Text);
                        command.Parameters.AddWithValue("@DepartureTime", DateTime.TryParse(txtTime.Text, out DateTime depTime) ? depTime : DateTime.MinValue);
                        command.Parameters.AddWithValue("@SeatsAvailable", int.TryParse(txtSeats.Text, out int seats) ? seats : 0);
                        command.Parameters.AddWithValue("@BusID", busId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Redirect to Manage Buses page
                Response.Redirect("~/Pages/CompanyBus.aspx");
            }
        }
    }
}
