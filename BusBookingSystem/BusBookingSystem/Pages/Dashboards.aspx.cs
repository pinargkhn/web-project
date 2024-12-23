using System;
using System.Web.UI;

namespace BusBookingSystem.Pages
{
    public partial class Dashboards : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null || Session["IsDeveloper"] == null || !(bool)Session["IsDeveloper"])
                {
                    Response.Redirect("~/Pages/logIn.aspx");
                }
            }
        }

        protected void btnManageUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/Users.aspx");
        }

        protected void btnManageBuses_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/Buses.aspx");
        }

        protected void btnManageCompanies_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/Companies.aspx");
        }

        protected void btnManageBookings_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/Bookings.aspx");
        }
    }
}