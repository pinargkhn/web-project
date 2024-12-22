using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace BusBookingSystem.Pages
{
    public partial class EditCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string companyId = Request.QueryString["CompanyID"];
                if (!string.IsNullOrEmpty(companyId))
                {
                    LoadCompanyDetails(companyId);
                }
            }
        }

        private void LoadCompanyDetails(string companyId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = "SELECT CompanyName FROM companies WHERE CompanyID = @CompanyID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyID", companyId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtCompanyName.Text = reader["CompanyName"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string companyId = Request.QueryString["CompanyID"];
            string companyName = txtCompanyName.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = "UPDATE companies SET CompanyName = @CompanyName WHERE CompanyID = @CompanyID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyID", companyId);
                    command.Parameters.AddWithValue("@CompanyName", companyName);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Redirect("~/Pages/Dashboard/Companies.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/Companies.aspx");
        }
    }
}
