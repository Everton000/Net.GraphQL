using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;

namespace Net.GraphQL.Queries;

[ExtendObjectType("Query")]
public class OrderQuery
{
    public async Task<Order> GetOrderById([Service] IOrderService orderService, int id) => await orderService.GetById(id);

    public async Task<ICollection<Order>> GetOrders([Service] IOrderService orderService) => await orderService.GetAll();
}
