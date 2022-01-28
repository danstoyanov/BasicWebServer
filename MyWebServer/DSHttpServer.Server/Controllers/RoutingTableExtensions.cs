using DSHttpServer.Server.HTTP;
using DSHttpServer.Server.HTTP.RoutingTables;
using System;

namespace DSHttpServer.Server.Controllers
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TConroller>(
            this IRoutingTable routingTable,
            string path,
            Func<TConroller, Response> controllerFunction)
            where TConroller : Controller
            => routingTable.MapGet(path, request => controllerFunction(
                CreateController<TConroller>(request)));

        public static IRoutingTable MapPost<TConroller>(
            this IRoutingTable routingTable,
            string path,
            Func<TConroller, Response> controllerFunction)
            where TConroller : Controller
            => routingTable.MapGet(path, request => controllerFunction(
                CreateController<TConroller>(request)));

        private static TController CreateController<TController>(Request request)
            => (TController)Activator
            .CreateInstance(typeof(TController), new[] { request });
    }
}
