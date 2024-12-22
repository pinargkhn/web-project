using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace BusBookingSystem.Pages
{
    public partial class Users_AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccessFrom"] == null || Session["AccessFrom"].ToString() != "CompanyBus")
            {
                Response.Redirect("~/Pages/Dashboard/Users.aspx");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string query = "INSERT INTO users (Username, PasswordHash, Email) VALUES (@Username, @PasswordHash, @Email)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", password);
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Redirect("~/Pages/Dashboard/Users.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/Users.aspx");
        }
    }
}
