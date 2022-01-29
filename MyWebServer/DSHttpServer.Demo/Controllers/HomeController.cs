using DSHttpServer.Server.Controllers;
using DSHttpServer.Server.HTTP;

namespace DSHttpServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
            Name: <input type='text' name='Name'/>
            Age: <input type='number' name ='Age'/>
            <input type='submit' value ='Save' />
        </form>";

        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index() => Text("Hello from the server !");

        public Response Redirect() => Redirect("https://github.com/");

        public Response Html() => Html(HomeController.HtmlForm);
    }
}
