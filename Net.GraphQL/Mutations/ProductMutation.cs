using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;
using Net.GraphQL.InputTypes.Product;

namespace Net.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class ProductMutation
{
    public async Task<Product> InsertProduct([Service] IProductService productService, CreateProductInputType createProductInputType)
    {
        var product = new Product
        {
            Name = createProductInputType.Name,
            Description = createProductInputType.Description,
            Price = createProductInputType.Price
        };
        await productService.Insert(product);
        return product;
    }

    public async Task<Product> UpdateProduct([Service] IProductService productService, UpdateProductInputType updateProductInputType)
    {
        var product = new Product
        {
            Id = updateProductInputType.Id,
            Name = updateProductInputType.Name,
            Description = updateProductInputType.Description,
            Price = updateProductInputType.Price
        };
        await productService.Update(product);
        return product;
    }

    public async Task<bool> DeleteProduct([Service] IProductService productService, int id)
    {
        await productService.Delete(id);
        return true;
    }
}
