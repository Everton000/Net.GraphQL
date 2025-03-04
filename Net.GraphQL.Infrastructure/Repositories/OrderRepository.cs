using Microsoft.EntityFrameworkCore;
using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;
using Net.GraphQL.Infrastructure.Data;

namespace Net.GraphQL.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Delete(int id)
    {
        Order? order = await _context.Orders.FindAsync(id);

        if (order == null) return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ICollection<Order>> GetAll()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order?> GetById(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task Insert(Order order)
    {
        int[] idsProducts = order.Products!.Select(p => p.Id).ToArray();
        List<Product> products = await _context.Products
            .Where(p => idsProducts.Contains(p.Id))
            .ToListAsync();

        order.Products = products;

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }
}
