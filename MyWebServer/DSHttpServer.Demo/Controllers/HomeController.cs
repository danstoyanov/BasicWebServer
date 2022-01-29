using System;

using DSHttpServer.Server.HTTP;
using DSHttpServer.Server.Controllers;

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

        public Response HtmlFormPost()
        {
            string formData = string.Empty;

            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }
    }
}
