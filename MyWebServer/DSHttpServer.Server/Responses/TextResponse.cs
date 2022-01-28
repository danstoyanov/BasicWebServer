using System;

using DSHttpServer.Server.HTTP;

namespace DSHttpServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text, 
            Action<Request, Response> preRenderAction = null)
            : base(text, ContentType.PlainText, preRenderAction)
        {

        }
    }
}
