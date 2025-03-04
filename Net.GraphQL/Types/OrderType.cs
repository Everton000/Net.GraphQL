using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Resolvers;

namespace Net.GraphQL.Types;

public class OrderType : ObjectType<Order>
{
    protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
    {
        descriptor
            .Field(o => o.Products)
            .ResolveWith<OrderResolver>(r => r.GetProducts(default!, default!, default!));
    }
}
