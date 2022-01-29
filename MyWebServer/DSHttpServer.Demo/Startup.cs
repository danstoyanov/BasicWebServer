using System.Threading.Tasks;

using DSHttpServer.Server;
using DSHttpServer.Server.HTTP;
using DSHttpServer.Demo.Controllers;
using DSHttpServer.Server.RoutingTables;

namespace DSHttpServer.Demo
{
    public class Startup
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                .MapGet<HomeController>("/", c => c.Index())
                .MapGet<HomeController>("/Redirect", c => c.Redirect())
                .MapGet<HomeController>("/HTML", c => c.Html())
                .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
                .MapGet<HomeController>("/Content", c => c.Content())
                .MapPost<HomeController>("/Content", c => c.DownloadContent())
                .MapGet<HomeController>("/Cookies", c => c.Cookies())
                .MapGet<HomeController>("/Session", c => c.Session())
                .MapGet<UsersController>("/Login", c => c.Login())
                .MapPost<UsersController>("/Login", c => c.LogInUser())
            )
            .Start();

        private static void GetUserDataAction(Request request, Response response)
        {
            if (request.Session.ContainsKey(Session.SessionCurrentDateKey))
            {
                response.Body = "";
                response.Body += $"<h3>Currently logged-in user " +
                    "is with username '{Username}'</h3>";
            }
            else
            {
                response.Body = "";
                response.Body += "<h3>You should first log in " +
                    "- <a href='/Login'>Login</a></h3>";
            }
        }

        private static void LogoutAction(Request request, Response response)
        {
            var sessionBeforeClear = request.Session;

            request.Session.Clear();

            var sessionAfterClear = request.Session;

            response.Body = "";
            response.Body += "<h3>Logged out successfully!</h3>";
        }
    }
}
