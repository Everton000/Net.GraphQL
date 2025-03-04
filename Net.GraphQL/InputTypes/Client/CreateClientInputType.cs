namespace Net.GraphQL.InputTypes.Client;

public class CreateClientInputType
{
    public string Name { get; set; } = String.Empty;
    public string CpfOrCnpj { get; set; } = String.Empty;
}
