using Net.GraphQL.DataLoaders;
using Net.GraphQL.Domain.Entities;

namespace Net.GraphQL.Resolvers;

public class OrderResolver
{
    public async Task<IEnumerable<Product>> GetProducts(
            Order order,
            ProductByOrderDataLoader dataLoader,
            CancellationToken cancellationToken
        )
    {
        return await dataLoader.LoadAsync(order.Id, cancellationToken);
    }
}
