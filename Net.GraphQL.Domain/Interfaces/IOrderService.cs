using Net.GraphQL.Domain.Entities;

namespace Net.GraphQL.Domain.Interfaces;

public interface IOrderService
{
    Task Insert(Order order);
    Task<Order> GetById(int id);
    Task Update(Order order);
    Task Delete(int id);
    Task<ICollection<Order>> GetAll();
}
