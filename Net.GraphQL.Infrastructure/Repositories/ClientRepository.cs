using Microsoft.EntityFrameworkCore;
using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;
using Net.GraphQL.Infrastructure.Data;

namespace Net.GraphQL.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Delete(int id)
    {
        Client? client = await _context.Clients.FindAsync(id);

        if (client == null) return false;

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ICollection<Client>> GetAll(List<string> selectedFields)
    {
        return await _context.Clients
            .AsNoTracking()
            .Select(c => new Client
            {
                Id = selectedFields.Contains("id") ? c.Id : 0,
                Name = selectedFields.Contains("name") ? c.Name : string.Empty,
                LastName = selectedFields.Contains("lastName") ? c.LastName : null,
                CpfOrCnpj = selectedFields.Contains("cpfOrCnpj") ? c.CpfOrCnpj : string.Empty,
                DateOfBirth = selectedFields.Contains("dateOfBirth") ? c.DateOfBirth : null,
                CreatedAt = selectedFields.Contains("createdAt") ? c.CreatedAt : DateTime.UtcNow,
                UpdatedAt = selectedFields.Contains("updatedAt") ? c.UpdatedAt : null,
            })
            .ToListAsync();
    }

    public async Task<Client?> GetById(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task Insert(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Client client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
    }
}
