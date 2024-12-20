using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Web
{
    public partial class logIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoginSubmitButton(object sender, EventArgs e)
        {
            string user = username.Value.Trim();
            string pass = password.Value.Trim();

            if (Validation.UsernameLength(user) && Validation.PasswordLength(pass))
            {
                Response.Write("<script>alert('Login successful')</script>");
                Session["username"] = user;
                Response.Redirect($"~/profile.aspx?username={user}");
            }
            else if (!Validation.UsernameLength(user))
            {
                Response.Write("<script>alert('Username cannot be less than 3 or more than 50')</script>");
            }
            else if (!Validation.PasswordLength(pass))
            {
                Response.Write("<script>alert('Password cannot be less than 8 or more than 50')</script>");
            }
            else  Response.Write("<script>alert('Something wrong happened!')</script>");
        }
    }
}