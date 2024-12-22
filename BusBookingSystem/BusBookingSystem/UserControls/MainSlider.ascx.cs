using BusBookingSystem.Pages;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;

namespace BusBookingSystem.UserControls
{
    public partial class MainSlider : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Get user input from the control
            string departure = departureLocation.Text.Trim();
            string arrival = arrivalLocation.Text.Trim();
            string date = txtDate.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(departure) || string.IsNullOrEmpty(arrival) || string.IsNullOrEmpty(date))
            {
                return;
            }

            // Redirect to the Book page with query string parameters
            string url = $"Book.aspx?departure={HttpUtility.UrlEncode(departure)}&arrival={HttpUtility.UrlEncode(arrival)}&date={HttpUtility.UrlEncode(date)}";
            Response.Redirect(url);
        }
    }

}