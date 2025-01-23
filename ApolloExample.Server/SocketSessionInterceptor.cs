using HotChocolate.AspNetCore.Subscriptions.Protocols;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.AspNetCore;
using System.Reflection.PortableExecutable;

namespace ApolloExample.Server
{
    public class SocketSessionInterceptor : DefaultSocketSessionInterceptor
    {
        public override ValueTask<ConnectionStatus> OnConnectAsync(ISocketSession session, IOperationMessagePayload connectionInitMessage, CancellationToken cancellationToken = default)
        {
            session.Connection.HttpContext.Request.Headers
                .ToList()
                .ForEach(header => Console.WriteLine($"{header.Key}: {header.Value}"));

            return base.OnConnectAsync(session, connectionInitMessage, cancellationToken);
        }
    }
}
