using HotChocolate.Authorization;

namespace ApolloExample.Server
{
    [Authorize]
    public class Query
    {
        public Book GetBook() => new();
    }
}
