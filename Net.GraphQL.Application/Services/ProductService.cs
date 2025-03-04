using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;

namespace Net.GraphQL.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Insert(Product product)
    {
        await _productRepository.Insert(product);
    }

    public async Task<Product> GetById(int id)
    {
        Product product = await _productRepository.GetById(id)
            ?? throw new Exception("The product id is invalid.");

        return product;
    }

    public async Task Update(Product product)
    {
        await _productRepository.Update(product);
    }
    public async Task Delete(int id)
    {
        bool result = await _productRepository.Delete(id);

        if (result == false) throw new Exception("The product id is invalid.");
    }

    public async Task<ICollection<Product>> GetAll()
    {
        return await _productRepository.GetAll();
    }

    public async Task<ICollection<Product>> GetByOrderIds(IEnumerable<int> orderIds)
    {
        return await _productRepository.GetByOrderIds(orderIds);
    }
}
