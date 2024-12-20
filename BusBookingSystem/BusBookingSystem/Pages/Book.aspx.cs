using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace BusBookingSystem.Pages
{
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Optionally load some initial data or set up the page.
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Get user input.
            string departure = departureLocation.Text.Trim();
            string arrival = arrivalLocation.Text.Trim();
            string date = txtDate.Text.Trim();

            lblMessage.Text = "";

            // Check if input is empty before querying the database (optional validation).
            if (string.IsNullOrEmpty(departure) || string.IsNullOrEmpty(arrival) || string.IsNullOrEmpty(date))
            {
                lblMessage.Text = "Please fill in all fields before searching.";
                lblMessage.Visible = true;
                return;
            }

            // Database connection string.
            string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT * FROM Buses WHERE DepartureLocation = @Departure AND ArrivalLocation = @Arrival AND DATE(DepartureTime) = @Date";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection.
                    cmd.Parameters.AddWithValue("@Departure", departure);
                    cmd.Parameters.AddWithValue("@Arrival", arrival);
                    cmd.Parameters.AddWithValue("@Date", date);

                    try
                    {
                        // Open connection and execute query.
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            // Bind data to GridView and make it visible.
                            gvBuses.DataSource = dt;
                            gvBuses.DataBind();
                            gvBuses.Visible = true;

                            // Hide "No Results" message if any results are found.
                            lblNoResults.Visible = false;
                        }
                        else
                        {
                            // No results found.
                            gvBuses.Visible = false;
                            lblNoResults.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception and show an error message.
                        lblMessage.Text = "Error occurred while searching for buses: " + ex.Message;
                        lblMessage.Visible = true;
                    }
                }
            }
        }

        protected void gvBuses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Book")
            {
                int busID = Convert.ToInt32(e.CommandArgument);

                // Check for login (CustomerID from Session)
                /// auth sistemi yapılınca alt kısmı uncommentleyeceğiz, şu anlık test için auth check'i devre dısı bıraktım
                //int customerID = Convert.ToInt32(Session["CustomerID"]);

                //if (customerID <= 0)
                //{
                //    lblMessage.Text = "You must be logged in to make a booking.";
                //    lblMessage.CssClass = "error-message";
                //    return;
                //}

                // Database connection string
                string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();

                        // Check if there are available seats
                        string checkSeatsQuery = "SELECT SeatsAvailable FROM buses WHERE BusID = @BusID";
                        int seatsAvailable = 0;

                        using (MySqlCommand cmd = new MySqlCommand(checkSeatsQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@BusID", busID);
                            seatsAvailable = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        if (seatsAvailable <= 0)
                        {
                            // No available seats for this bus
                            lblMessage.Text = "No available seats left for this bus.";
                            lblMessage.CssClass = "error-message";
                            return;
                        }

                        // Start a transaction to handle both the insert and update atomically
                        using (var transaction = conn.BeginTransaction())
                        {
                            // Insert a new booking record
                            string insertQuery = "INSERT INTO bookings (CustomerID, BusID, BookingDate, Status) VALUES (@CustomerID, @BusID, @BookingDate, @Status)";
                            using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction))
                            {
                                // cmd.Parameters.AddWithValue("@CustomerID", customerID);
                                /// auth sistemi yapıldıktan sonra üstteki satırı uncomment edip alttaki satırı silebiliriz, test için customer id 0 olarak ekliyor şu anda.
                                cmd.Parameters.AddWithValue("@CustomerID", 0);
                                cmd.Parameters.AddWithValue("@BusID", busID);
                                cmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Status", "Booked"); // Booked, Cancelled

                                cmd.ExecuteNonQuery();
                            }

                            // Update available seats for the bus
                            string updateSeatsQuery = "UPDATE buses SET SeatsAvailable = SeatsAvailable - 1 WHERE BusID = @BusID AND SeatsAvailable > 0";
                            using (MySqlCommand cmd = new MySqlCommand(updateSeatsQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@BusID", busID);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected == 0)
                                {
                                    // If no rows were affected, it means there are no seats available
                                    lblMessage.Text = "No available seats left for this bus.";
                                    lblMessage.CssClass = "error-message";
                                    transaction.Rollback(); // Rollback the transaction as the booking cannot be made
                                    return;
                                }
                            }

                            // Commit the transaction if everything is successful
                            transaction.Commit();
                        }

                        // Display a success message
                        // Later on, we can create the BookingConfirmation page (optional)
                        lblMessage.Text = $"Bus with ID {busID} booked successfully!";
                        lblMessage.CssClass = "success-message";

                        // Reload the GridView to show updated data
                        gvBuses.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        lblMessage.Text = "An error occurred while processing your booking. Please try again.";
                        lblMessage.CssClass = "error-message";
                    }
                }
            }
        }

    }
}