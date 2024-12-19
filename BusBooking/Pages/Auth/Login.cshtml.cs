using Microsoft.AspNetCore.Mvc;

    if (Validation.UsernameLength(user) && Validation.PasswordLength(pass) && Query.Login(user, pass))
    if (!Validation.UsernameLength(user) || !Validation.PasswordLength(pass) || !Query.Login(user, pass))
    {
...
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusBooking.Pages.Auth
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        protected void LoginSubmitButton(String username, String password)
        {
            string user = username.Value.Trim();
            string pass = password.Value.Trim();

            if (Validation.UsernameLength(user) && Validation.PasswordLength(pass) && Query.Login(user, pass))
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
            else if (!Query.Login(user, pass))
            {
                Response.Write("<script>alert('Username or password is wrong!')</script>");
            }
            else Response.Write("<script>alert('Something wrong happened!')</script>");
        }
    }
}
