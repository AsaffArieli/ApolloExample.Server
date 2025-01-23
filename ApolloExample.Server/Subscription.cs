using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;

namespace ApolloExample.Server
{
    [Authorize]
    public class Subscription
    {
        [Subscribe(With = nameof(BookStream))]
        public Book OnBookRecieved([EventMessage] Book book) => book;

        public async IAsyncEnumerable<Book> BookStream()
        {
            for (var i = 0; i < 10; i++)
            {
                yield return new Book();
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}
