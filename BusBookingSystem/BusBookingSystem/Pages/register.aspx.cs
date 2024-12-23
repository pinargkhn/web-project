using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Web
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterSubmitButton(object sender, EventArgs e)
        {
            string user = username.Value.Trim();
            string mail = email.Value.Trim();
            string pass = newPassword.Value.Trim();

            if (Validation.UsernameLength(user) && Validation.Password(pass) && Validation.Mail(mail) && !Query.IsTaken(user))
            {
                Response.Write("<script>alert('Register successful')</script>");
                Query.Register(user, mail, pass);
                Session["username"] = user;
                Response.Redirect($"~/Pages/Login.aspx?username={user}");
            }
            else if (!Validation.UsernameLength(user))
            {
                Response.Write("<script>alert('Username cannot be less than 3 or more than 50')</script>");
            }
            else if (!Validation.Password(pass))
            {
                Response.Write("<script>alert('Password has to contain one digit and letter also cannot be less than 8 or more than 50')</script>");
            }
            else if (!Validation.Mail(mail))
            {
                Response.Write("<script>alert('Invalid Mail!')</script>");
            }
            else if (Query.IsTaken(user))
            {
                Response.Write("<script>alert('Username Is Taken!')</script>");
            }
            else Response.Write("<script>alert('Something wrong happened!')</script>");
        }
    }
}