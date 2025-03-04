using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;
using Net.GraphQL.InputTypes.Client;

namespace Net.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class ClientMutation
{
    public async Task<Client> InsertClient([Service] IClientService clientService, CreateClientInputType createClientInputType)
    {
        var client = new Client
        {
            Name = createClientInputType.Name,
            CpfOrCnpj = createClientInputType.CpfOrCnpj
        };
        await clientService.Insert(client);
        return client;
    }

    public async Task<Client> UpdateClient([Service] IClientService clientService, UpdateClientInputType updateClientInputType)
    {
        var client = new Client
        {
            Id = updateClientInputType.Id,
            Name = updateClientInputType.Name,
            CpfOrCnpj = updateClientInputType.CpfOrCnpj
        };
        await clientService.Update(client);
        return client;
    }

    public async Task<bool> DeleteClient([Service] IClientService clientService, int id)
    {
        await clientService.Delete(id);
        return true;
    }
}
