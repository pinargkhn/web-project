using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace BusBookingSystem.Pages
{
    public partial class Buses_EditBus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccessFrom"] == null || Session["AccessFrom"].ToString() != "CompanyBus")
            {
                Response.Redirect("~/Pages/Dashboard/Buses.aspx");
            }

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
            string query = @"SELECT BusName, DepartureLocation, ArrivalLocation, DepartureTime, SeatsAvailable 
                             FROM buses WHERE BusID = @BusID";

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
                            txtDepartureLocation.Text = reader["DepartureLocation"].ToString();
                            txtArrivalLocation.Text = reader["ArrivalLocation"].ToString();
                            txtDepartureTime.Text = reader["DepartureTime"].ToString();
                            txtSeatsAvailable.Text = reader["SeatsAvailable"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string busId = Request.QueryString["BusID"];
            string busName = txtBusName.Text.Trim();
            string departureLocation = txtDepartureLocation.Text.Trim();
            string arrivalLocation = txtArrivalLocation.Text.Trim();
            string departureTime = txtDepartureTime.Text.Trim();
            int seatsAvailable = int.TryParse(txtSeatsAvailable.Text, out int seats) ? seats : 0;

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string query = @"UPDATE buses SET BusName = @BusName, DepartureLocation = @DepartureLocation, 
                             ArrivalLocation = @ArrivalLocation, DepartureTime = @DepartureTime, 
                             SeatsAvailable = @SeatsAvailable WHERE BusID = @BusID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BusID", busId);
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
