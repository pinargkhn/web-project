using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingSystem.Pages
{
    public partial class Companies : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCompanies();
            }
        }

        private void LoadCompanies()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = "SELECT CompanyID, CompanyName FROM companies";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable companiesTable = new DataTable();
                        companiesTable.Load(reader);

                        gvCompanies.DataSource = companiesTable;
                        gvCompanies.DataBind();
                    }
                }
            }
        }

        protected void gvCompanies_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int companyId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditCompany")
            {
                Response.Redirect($"~/Pages/Dashboard/Companies_EditCompany.aspx?CompanyID={companyId}");
            }
            else if (e.CommandName == "DeleteCompany")
            {
                DeleteCompany(companyId);
                LoadCompanies();
            }
        }

        protected void btnAddCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/Companies_AddCompany.aspx");
        }

        private void DeleteCompany(int companyId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = "DELETE FROM companies WHERE CompanyID = @CompanyID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyID", companyId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
