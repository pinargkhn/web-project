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
                string departure = Request.QueryString["departure"];
                string arrival = Request.QueryString["arrival"];
                string date = Request.QueryString["date"];

                if (!string.IsNullOrEmpty(departure) && !string.IsNullOrEmpty(arrival) && !string.IsNullOrEmpty(date))
                {
                    PerformSearch(departure, arrival, date);
                }

                txtSeatCount.Visible = false;
            }
        }

        public void PerformSearch(string departure, string arrival, string date)
        {
            lblMessage.Text = "";
            txtSeatCount.Visible = false;

            if (string.IsNullOrEmpty(departure) || string.IsNullOrEmpty(arrival) || string.IsNullOrEmpty(date))
            {
                lblMessage.Text = "Please fill in all fields before searching.";
                lblMessage.Visible = true;
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT * FROM Buses WHERE DepartureLocation = @Departure AND ArrivalLocation = @Arrival AND DATE(DepartureTime) = @Date";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Departure", departure);
                    cmd.Parameters.AddWithValue("@Arrival", arrival);
                    cmd.Parameters.AddWithValue("@Date", date);

                    try
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            gvBuses.DataSource = dt;
                            gvBuses.DataBind();
                            gvBuses.Visible = true;
                            txtSeatCount.Visible = true;

                            lblNoResults.Visible = false;
                        }
                        else
                        {
                            gvBuses.Visible = false;
                            txtSeatCount.Visible = false;
                            lblNoResults.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Error occurred while searching for buses: " + ex.Message;
                        lblMessage.Visible = true;
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Get user input.
            string departure = departureLocation.Text.Trim();
            string arrival = arrivalLocation.Text.Trim();
            string date = txtDate.Text.Trim();

            // Call the PerformSearch method.
            PerformSearch(departure, arrival, date);
        }

        protected void gvBuses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Book")
            {
                int busID = Convert.ToInt32(e.CommandArgument);

                int customerID = Convert.ToInt32(Session["CustomerID"]);

                if (customerID <= 0)
                {
                    lblMessage.Text = "You must be logged in to make a booking.";
                    lblMessage.CssClass = "error-message";
                    return;
                }

                int seatCount = 0;
                if (!int.TryParse(txtSeatCount.Text, out seatCount) || seatCount <= 0)
                {
                    lblMessage.Text = "Please enter a valid seat count.";
                    lblMessage.CssClass = "error-message";
                    return;
                }

                // Database connection string
                string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();

                        string checkSeatsQuery = "SELECT SeatsAvailable FROM buses WHERE BusID = @BusID";
                        int seatsAvailable = 0;

                        using (MySqlCommand cmd = new MySqlCommand(checkSeatsQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@BusID", busID);
                            seatsAvailable = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        if (seatsAvailable < seatCount)
                        {
                            lblMessage.Text = $"Only {seatsAvailable} seats are available for this bus.";
                            lblMessage.CssClass = "error-message";
                            return;
                        }

                        using (var transaction = conn.BeginTransaction())
                        {
                            string insertQuery = "INSERT INTO bookings (CustomerID, BusID, BookingDate, Status) VALUES (@CustomerID, @BusID, @BookingDate, @Status)";
                            for (int i = 0; i < seatCount; i++)
                            {
                                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                                    cmd.Parameters.AddWithValue("@BusID", busID);
                                    cmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@Status", "Booked");

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            string updateSeatsQuery = "UPDATE buses SET SeatsAvailable = SeatsAvailable - @SeatCount WHERE BusID = @BusID AND SeatsAvailable >= @SeatCount";
                            using (MySqlCommand cmd = new MySqlCommand(updateSeatsQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@BusID", busID);
                                cmd.Parameters.AddWithValue("@SeatCount", seatCount);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected == 0)
                                {
                                    lblMessage.Text = "Not enough available seats left for this bus.";
                                    lblMessage.CssClass = "error-message";
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            transaction.Commit();
                        }

                        lblMessage.Text = $"{seatCount} seats successfully booked for Bus ID {busID}!";
                        lblMessage.CssClass = "success-message";

                        gvBuses.DataBind();
                        txtSeatCount.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "An error occurred while processing your booking. Please try again.";
                        lblMessage.CssClass = "error-message";
                    }
                }
            }
        }
    }
}