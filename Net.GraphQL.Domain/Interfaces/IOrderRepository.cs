using Net.GraphQL.Domain.Entities;

namespace Net.GraphQL.Domain.Interfaces;

public interface IOrderRepository
{
    Task Insert(Order order);
    Task<Order?> GetById(int id);
    Task Update(Order order);
    Task<bool> Delete(int id);
    Task<ICollection<Order>> GetAll();
}
