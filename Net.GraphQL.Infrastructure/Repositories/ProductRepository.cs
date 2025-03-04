using Microsoft.EntityFrameworkCore;
using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;
using Net.GraphQL.Infrastructure.Data;

namespace Net.GraphQL.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Delete(int id)
    {
        Product? product = await _context.Products.FindAsync(id);

        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ICollection<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task Insert(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Product>> GetByOrderIds(IEnumerable<int> orderIds)
    {
        return await _context.Products
            .Where(p => p.Orders != null &&
                p.Orders.Any(o => orderIds.Contains(o.Id)))
            .ToListAsync();
    }
}
