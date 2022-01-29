using DSHttpServer.Server.Controllers;
using DSHttpServer.Server.HTTP;

namespace DSHttpServer.Demo.Controllers
{
    public class UsersController : Controller
    {
        public UsersController(Request request) 
            : base(request)
        {

        }
    }
}
