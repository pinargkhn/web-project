using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingSystem.Pages
{
    public partial class Users : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        private void LoadUsers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = @"
                SELECT 
                    UserID, 
                    Username, 
                    PasswordHash, 
                    Email, 
                    CompanyID, 
                    IsAdmin, 
                    IsDeveloper 
                FROM users";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable usersTable = new DataTable();
                        usersTable.Load(reader);

                        gvUsers.DataSource = usersTable;
                        gvUsers.DataBind();
                    }
                }
            }
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditUser")
            {
                Session["AccessFrom"] = "CompanyBus";
                Response.Redirect($"~/Pages/Dashboard/Users_EditUser.aspx?UserID={userId}");
            }
            else if (e.CommandName == "DeleteUser")
            {
                DeleteUser(userId);
                LoadUsers();
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Session["AccessFrom"] = "CompanyBus";
            Response.Redirect("~/Pages/Dashboard/Users_AddUser.aspx");
        }

        protected void chkIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            int userId = Convert.ToInt32(chkBox.ToolTip);
            bool isAdmin = chkBox.Checked;

            UpdateUserRole(userId, "IsAdmin", isAdmin);
            LoadUsers(); // Refresh data
        }

        protected void chkIsDeveloper_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            int userId = Convert.ToInt32(chkBox.ToolTip);
            bool isDeveloper = chkBox.Checked;

            UpdateUserRole(userId, "IsDeveloper", isDeveloper);
            LoadUsers(); // Refresh data
        }

        private void UpdateUserRole(int userId, string column, bool value)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = $"UPDATE users SET {column} = @Value WHERE UserID = @UserID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value", value ? 1 : 0);
                    command.Parameters.AddWithValue("@UserID", userId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void DeleteUser(int userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = "DELETE FROM users WHERE UserID = @UserID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool isAdmin = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsAdmin"));
                if (isAdmin)
                {
                    e.Row.BackColor = System.Drawing.Color.LightYellow; // Admin kullanıcıyı vurgula
                }
            }
        }
    }
}
