using System;
using System.Web.UI;

namespace BusBookingSystem.UserControls
{
    public partial class NavigationMenu : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool isLoggedIn = Session["CustomerID"] != null;
                bool isAdmin = Session["IsAdmin"] != null && (bool)Session["IsAdmin"];
                bool isDeveloper = Session["IsDeveloper"] != null && (bool)Session["IsDeveloper"];

                adminMenu.Visible = isAdmin;
                developerMenu.Visible = isDeveloper;
                loginMenu.Visible = !isLoggedIn;
                pastTrips.Visible = isLoggedIn;
                logOut.Visible = isLoggedIn;
            }
        }
    }
}