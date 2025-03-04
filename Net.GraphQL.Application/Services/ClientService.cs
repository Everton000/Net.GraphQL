using Net.GraphQL.Application.Helpers;
using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;

namespace Net.GraphQL.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task Insert(Client client)
    {
        if (DocumentValidatorHelper.IsValidCPFCNPJ(client.CpfOrCnpj) == false)
        {
            throw new Exception("CpfOrCnpj is invalid.");
        }

        await _clientRepository.Insert(client);
    }

    public async Task<Client> GetById(int id)
    {
        Client client = await _clientRepository.GetById(id)
            ?? throw new Exception("The client id is invalid.");

        return client;
    }

    public async Task Update(Client client)
    {
        await _clientRepository.Update(client);
    }
    public async Task Delete(int id)
    {
        bool result = await _clientRepository.Delete(id);

        if (result == false) throw new Exception("The client id is invalid.");
    }

    public async Task<ICollection<Client>> GetAll(List<string> selectedFields)
    {
        return await _clientRepository.GetAll(selectedFields);
    }
}
