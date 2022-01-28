using System;

using DSHttpServer.Server.HTTP;
using DSHttpServer.Server.HTTP.RoutingTables;
using DSHttpServer.Server.RoutingTables;

namespace DSHttpServer.Server.Controllers
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, Response> controllerFunction) where TController : Controller
        => routingTable.Map(
            Method.Get,
            path,
            request => controllerFunction(CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(
            this RoutingTable routingTable,
            string path,
            Func<TController, Response> controllerFunction) where TController : Controller
        => routingTable.Map(
            Method.Post,
            path,
            request => controllerFunction(CreateController<TController>(request)));

        private static TController CreateController<TController>(Request request)
            => (TController)Activator.CreateInstance(typeof(TController), new[] { request });
    }
}
