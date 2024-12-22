using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI;

namespace BusBookingSystem.Pages
{
    public partial class CompanyBus : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || !(Session["isAdmin"] is bool && (bool)Session["isAdmin"]))
            {
                Response.Redirect("~/Pages/Book.aspx");
            }

            if (!IsPostBack)
            {
                LoadBuses();
                Session.Remove("AccessFrom");
            }
        }

        private void LoadBuses()
        {
            int customerId = Convert.ToInt32(Session["CustomerID"]);

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = @"SELECT 
                BusID, 
                BusName, 
                DepartureLocation, 
                ArrivalLocation, 
                COALESCE(DepartureTime, '1970-01-01 00:00:00') AS DepartureTime, 
                SeatsAvailable 
                FROM buses ";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable busesTable = new DataTable();
                        busesTable.Load(reader);

                        if (busesTable.Rows.Count > 0)
                        {
                            gvBuses.DataSource = busesTable;
                            gvBuses.DataBind();
                            lblNoBuses.Visible = false;
                        }
                        else
                        {
                            gvBuses.DataSource = null;
                            gvBuses.DataBind();
                            lblNoBuses.Visible = true;
                        }
                    }
                }
            }
        }

        protected void btnAddBus_Click(object sender, EventArgs e)
        {
            Session["AccessFrom"] = "CompanyBus";
            Response.Redirect("~/Pages/AddBus.aspx");
        }

        protected void gvBuses_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditBus")
            {
                string busId = e.CommandArgument.ToString();
                Session["AccessFrom"] = "CompanyBus";
                Response.Redirect($"~/Pages/EditBus.aspx?BusID={busId}");
            }
        }

        protected void gvBuses_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            string busId = gvBuses.DataKeys[e.RowIndex].Value.ToString();
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

            LoadBuses();
        }
    }
}
