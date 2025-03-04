using Net.GraphQL.Domain.Entities;

namespace Net.GraphQL.Domain.Interfaces;

public interface IProductService
{
    Task Insert(Product product);
    Task<Product> GetById(int id);
    Task Update(Product product);
    Task Delete(int id);
    Task<ICollection<Product>> GetAll();
    Task<ICollection<Product>> GetByOrderIds(IEnumerable<int> orderIds);
}
