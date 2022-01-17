using DSHttpServer.Server.HTTP;

namespace DSHttpServer.Server.Responses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse() 
            : base(StatusCode.NotFound)
        {

        }
    }
}
