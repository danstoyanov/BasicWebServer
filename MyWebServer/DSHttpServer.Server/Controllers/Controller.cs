

using DSHttpServer.Server.HTTP;
using DSHttpServer.Server.HTTP.Cookies;
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

        protected Response Html(string html, CookieCollection cookies = null)
        {
            var response = new HtmlResponse(html);

            if (cookies != null)
            {
                foreach (var cookie in cookies)
                {
                    response.Cookies.Add(cookie.Name, cookie.Value);
                }
            }

            return response;
        }

        protected Response BadRequest() => new BadRequestResponse();

        protected Response Unauthoriazed() => new UnauthorizedResponse();

        protected Response NotFount() => new NotFoundResponse();

        protected Response Redirect(string location) => new RedirectResponse(location);

        protected Response File(string fileName) => new TextFileResponse(fileName);
    }
}
