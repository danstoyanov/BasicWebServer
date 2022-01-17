using DSHttpServer.Server.HTTP;

namespace DSHttpServer.Server.Responses
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse() 
            : base(StatusCode.Unauthorized)
        {

        }
    }
}
