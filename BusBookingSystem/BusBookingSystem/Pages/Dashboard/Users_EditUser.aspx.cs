using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace BusBookingSystem.Pages
{
    public partial class Users_EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userId = Request.QueryString["UserID"];
                if (!string.IsNullOrEmpty(userId))
                {
                    LoadUserDetails(userId);
                }
            }
        }

        private void LoadUserDetails(string userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string query = "SELECT Username, PasswordHash, Email FROM users WHERE UserID = @UserID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUsername.Text = reader["Username"].ToString();
                            txtPassword.Text = reader["PasswordHash"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string userId = Request.QueryString["UserID"];
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string query = "UPDATE users SET Username = @Username, PasswordHash = @PasswordHash, Email = @Email WHERE UserID = @UserID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
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
