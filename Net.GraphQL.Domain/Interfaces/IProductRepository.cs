using Net.GraphQL.Domain.Entities;

namespace Net.GraphQL.Domain.Interfaces;

public interface IProductRepository
{
    Task Insert(Product product);
    Task<Product?> GetById(int id);
    Task Update(Product product);
    Task<bool> Delete(int id);
    Task<ICollection<Product>> GetAll();
    Task<ICollection<Product>> GetByOrderIds(IEnumerable<int> orderIds);
}
