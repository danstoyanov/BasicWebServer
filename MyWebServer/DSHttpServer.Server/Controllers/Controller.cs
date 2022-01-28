

using DSHttpServer.Server.HTTP;
using DSHttpServer.Server.Responses;

namespace DSHttpServer.Server.Controllers
{
    public abstract class Controller
    {
        public Controller(Request request)
        {
            this.Request = request;
        }

        protected Request Request { get; private init; }

        protected Response Text(string text) => new TextResponse(text);

        protected Response Html(string text) => new HtmlResponse(text);

        protected Response BadRequest() => new BadRequestResponse();

        protected Response Unauthoriazed() => new UnauthorizedResponse();

        protected Response NotFount() => new NotFoundResponse();

        protected Response Redirect(string location) => new RedirectResponse(location);

        protected Response File(string fileName) => new TextFileResponse(fileName);
    }
}
