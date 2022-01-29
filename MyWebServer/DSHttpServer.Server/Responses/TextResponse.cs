using System;

using DSHttpServer.Server.HTTP;

namespace DSHttpServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
            : base(text, ContentType.PlainText)
        {

        }
    }
}
