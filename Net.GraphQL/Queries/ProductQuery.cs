using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;

namespace Net.GraphQL.Queries;

[ExtendObjectType("Query")]
public class ProductQuery
{
    public async Task<Product> GetProductById([Service] IProductService productService, int id) => await productService.GetById(id);

    public async Task<ICollection<Product>> GetProducts([Service] IProductService productService) => await productService.GetAll();
}
