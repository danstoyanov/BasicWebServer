using DSHttpServer.Server.Controllers;
using DSHttpServer.Server.HTTP;

namespace DSHttpServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(Request request) 
            : base(request)
        {

        }
    }
}
