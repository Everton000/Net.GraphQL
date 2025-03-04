using Net.GraphQL.Domain.Entities;

namespace Net.GraphQL.Domain.Interfaces;

public interface IClientRepository
{
    Task Insert(Client client);
    Task<Client?> GetById(int id);
    Task Update(Client client);
    Task<bool> Delete(int id);
    Task<ICollection<Client>> GetAll(List<string> selectedFields);
}
