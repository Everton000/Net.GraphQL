using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;
using Net.GraphQL.InputTypes.Order;

namespace Net.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class OrderMutation
{
    public async Task<Order> InsertOrder([Service] IOrderService orderService,
        CreateOrderInputType createOrderInputType)
    {
        try
        {
            var products = createOrderInputType.IdsProducts.Select(id => new Product
            {
                Id = id
            }).ToList();

            var order = new Order
            {
                Code = Guid.NewGuid(),
                IdClient = createOrderInputType.IdClient,
                Products = products
            };
            await orderService.Insert(order);
            return order;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeleteOrder([Service] IOrderService orderService, int id)
    {
        await orderService.Delete(id);
        return true;
    }
}
