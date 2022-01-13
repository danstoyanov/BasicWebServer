using DSHttpServer.Server;
using System;

namespace DSHttpServer.Demo
{
    public class Startup
    {
        public static void Main()
        {
            var server = new HttpServer("127.0.0.1", 8080);
            server.Start();
        }
    }
}
