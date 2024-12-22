using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI;

namespace Web
{
    public partial class logIn : System.Web.UI.Page
    {
        protected void LoginSubmitButton(object sender, EventArgs e)
        {
            string user = username.Value.Trim();
            string pass = password.Value.Trim();

            if (Validation.UsernameLength(user) && Validation.PasswordLength(pass) && Query.Login(user, pass))
            {
                int customerId = Query.GetCustomerID(user); // Kullanıcı ID'sini veritabanından al
                bool isAdmin = Query.isAdmin(user); // Kullanıcı ID'sini veritabanından al
                bool isDeveloper = Query.isDeveloper(user); // Kullanıcı ID'sini veritabanından al
                Session["Username"] = user;
                Session["CustomerID"] = customerId; // Session'a CustomerID ekle
                Session["IsAdmin"] = isAdmin; // Session'a CustomerID ekle
                Session["IsDeveloper"] = isDeveloper; // Session'a CustomerID ekle

                if (isAdmin)
                { 
                    Response.Redirect("~/Pages/CompanyBus.aspx");
                }
                else if (isDeveloper)
                {
                    Response.Redirect("~/Pages/Dashboards.aspx");
                }
                else
                {
                    Response.Redirect("~/Pages/Book.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Username or password is wrong!')</script>");
            }
        }
    }

    
}
