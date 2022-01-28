using System;

namespace DSHttpServer.Server.HTTP.RoutingTables
{
    public interface IRoutingTable
    {
        IRoutingTable Map(Method method, string path, Func<Request, Response> responseFunction);
    }
}
