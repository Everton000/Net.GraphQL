namespace Net.GraphQL.InputTypes.Client;

public class UpdateClientInputType
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string CpfOrCnpj { get; set; } = String.Empty;
}
