using DSHttpServer.Server.Controllers;
using DSHttpServer.Server.HTTP;
using DSHttpServer.Server.HTTP.Cookies;

namespace DSHttpServer.Demo.Controllers
{
    public class UsersController : Controller
    {
        private const string Username = "user";

        private const string Password = "user123";

        public UsersController(Request request)
            : base(request)
        {

        }

        public Response Login() => View();

        public Response LogInUser()
        {
            this.Request.Session.Clear();

            var usernameMatches = this.Request.Form["Username"] == UsersController.Username;
            var passwordMaches = this.Request.Form["Password"] == UsersController.Password;

            if (usernameMatches && passwordMaches)
            {
                if (!this.Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    this.Request.Session[Session.SessionUserKey] = "MyUserId";

                    var cookies = new CookieCollection();
                    cookies.Add(Session.SessionCookieName, this.Request.Session.Id);

                    return Html("<h3>Logged successfuly!</h3>", cookies);
                }

                return Html("<h3>Logged successfuly!</h3>");
            }

            return Redirect("/Login");
        }

        public Response Logout()
        {
            this.Request.Session.Clear();

            return Html("<h3>Logged out successfully!</h3>");
        }

        public Response GetUserData()
        {
            if (this.Request.Session.ContainsKey(Session.SessionCurrentDateKey))
            {
                return Html($"<h3>Currently logged-in user " +
                    $"is with username <b>'{UsersController.Username}'</b></h3>");
            }

            return Redirect("/Login");
        }
    }
}
