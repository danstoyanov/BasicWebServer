using System;

using DSHttpServer.Server.HTTP;

namespace DSHttpServer.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text)
            : base (text, ContentType.Html)
        {

        }
    }
}
