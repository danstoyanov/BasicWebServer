using System;

using DSHttpServer.Server.HTTP;

namespace DSHttpServer.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text, 
            Action<Request, Response> preRenderAction = null)
            : base (text, ContentType.Html, preRenderAction)
        {

        }
    }
}
