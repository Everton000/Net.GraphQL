using HotChocolate.Types;
using Net.GraphQL.Domain.Entities;

namespace Net.GraphQL.Types;

public class ProductType : ObjectType<Product>
{
    protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
    {

    }
}
