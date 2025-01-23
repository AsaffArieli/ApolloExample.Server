using HotChocolate.AspNetCore.Subscriptions.Protocols;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.AspNetCore;

namespace ApolloExample.Server
{
    public class SocketSessionInterceptor : DefaultSocketSessionInterceptor
    {
        public override ValueTask<ConnectionStatus> OnConnectAsync(
            ISocketSession session,
            IOperationMessagePayload connectionInitMessage,
            CancellationToken cancellationToken = default)
        {
            // Access the HTTP context from the session
            var httpContext = session.Connection.HttpContext;

            // Log headers
            Console.WriteLine("Subscription Headers:");
            foreach (var header in httpContext.Request.Headers)
            {
                Console.WriteLine($"{header.Key}: {header.Value}");
            }

            // Optionally validate or modify the connection
            // Example: Reject the connection if a specific header is missing
            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                Console.WriteLine("Connection rejected: Authorization header is missing.");
                return ValueTask.FromResult(ConnectionStatus.Reject());
            }

            // Proceed with the default connection handling
            return base.OnConnectAsync(session, connectionInitMessage, cancellationToken);
        }
    }
}
