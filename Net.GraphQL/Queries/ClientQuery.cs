using HotChocolate.Language;
using HotChocolate.Resolvers;
using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;

namespace Net.GraphQL.Queries;

[ExtendObjectType("Query")]
public class ClientQuery
{
    public async Task<Client> GetClientById([Service] IClientService clientService, int id) => await clientService.GetById(id);

    public async Task<ICollection<Client>> GetClients([Service] IClientService clientService, IResolverContext context)
    {
        var selectedFields = context.Selection.SyntaxNode.SelectionSet!.Selections.Select(t => t.ToString()).ToList();

        return await clientService.GetAll(selectedFields);
    }
}
