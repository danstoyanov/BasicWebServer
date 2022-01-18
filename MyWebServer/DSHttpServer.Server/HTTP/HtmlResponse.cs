using System;

namespace DSHttpServer.Server.HTTP
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
