using DSHttpServer.Server.HTTP;

namespace DSHttpServer.Server.Responses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse() 
            : base(StatusCode.BadRequest)
        {

        }
    }
}
