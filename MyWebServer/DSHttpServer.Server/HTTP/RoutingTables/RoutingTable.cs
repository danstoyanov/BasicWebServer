using System;
using System.Collections.Generic;

using DSHttpServer.Server.Common;
using DSHttpServer.Server.Responses;
using DSHttpServer.Server.HTTP;
using DSHttpServer.Server.HTTP.RoutingTables;

namespace DSHttpServer.Server.RoutingTables
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Func<Request, Response>>> routes;

        public RoutingTable() => this.routes = new()
        {
            // Here if you want to add => new(StringComparer.InvariantCultureIgnoreCase) ....
            [Method.Get] = new(),
            [Method.Post] = new(),
            [Method.Put] = new(),
            [Method.Delete] = new()
        };

        public IRoutingTable Map(Method method, string path, Func<Request, Response> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            switch (method)
            {
                case Method.Get:
                    return MapGet(path, responseFunction);
                case Method.Post:
                    return MapPost(path, responseFunction);
                case Method.Put:
                case Method.Delete:
                default:
                    throw new ArgumentOutOfRangeException($"The method {nameof(method)} is not supported !");
            }
        }

        public IRoutingTable MapGet(string path, Func<Request, Response> responseFunction)
        {
            routes[Method.Get][path] = responseFunction;

            return this;
        }

        public IRoutingTable MapPost(string path, Func<Request, Response> responseFunction)
        {
            routes[Method.Post][path] = responseFunction;

            return this;
        }

        public Response MatchRequest(Request request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requestMethod)
                || !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requestMethod][requestUrl];

            return responseFunction(request);
        }
    }
}