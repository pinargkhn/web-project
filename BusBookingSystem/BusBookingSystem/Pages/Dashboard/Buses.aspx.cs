using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingSystem.Pages
{
    public partial class Buses : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBuses();
            }
        }

        private void LoadBuses()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string query = "SELECT BusID, BusName, DepartureLocation, ArrivalLocation, DepartureTime, SeatsAvailable FROM buses";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable busesTable = new DataTable();
                        busesTable.Load(reader);

                        gvBuses.DataSource = busesTable;
                        gvBuses.DataBind();
                    }
                }
            }
        }

        protected void gvBuses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditBus")
            {
                // Edit sayfasına yönlendirme
                int busId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"~/Pages/Dashboard/Buses_EditBus.aspx?BusID={busId}");
            }
            else if (e.CommandName == "DeleteBus")
            {
                // Silme işlemi
                int busId = Convert.ToInt32(e.CommandArgument);
                DeleteBus(busId);
                LoadBuses();
            }
        }

        private void DeleteBus(int busId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string query = "DELETE FROM buses WHERE BusID = @BusID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BusID", busId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void btnAddBus_Click(object sender, EventArgs e)
        {
            // Add sayfasına yönlendirme
            Response.Redirect("~/Pages/Dashboard/Buses_AddBus.aspx");
        }
    }
}