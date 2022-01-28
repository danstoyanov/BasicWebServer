

using DSHttpServer.Server.HTTP;
using DSHttpServer.Server.Headers;

namespace DSHttpServer.Server.Responses
{
    public class RedirectResponse : Response
    {
        public RedirectResponse(string location) 
            : base(StatusCode.Found)
        {
            this.Headers.Add(Header.Location, location);
        }
    }
}
