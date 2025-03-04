using Net.GraphQL.Application.Helpers;
using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;

namespace Net.GraphQL.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Insert(Order order)
    {
        await _orderRepository.Insert(order);
    }

    public async Task<Order> GetById(int id)
    {
        Order order = await _orderRepository.GetById(id)
            ?? throw new Exception("The order id is invalid.");

        return order;
    }

    public async Task Update(Order order)
    {
        await _orderRepository.Update(order);
    }
    public async Task Delete(int id)
    {
        bool result = await _orderRepository.Delete(id);

        if (result == false) throw new Exception("The order id is invalid.");
    }

    public async Task<ICollection<Order>> GetAll()
    {
        return await _orderRepository.GetAll();
    }
}
