namespace Net.GraphQL.Domain.Entities;

public class Client : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string CpfOrCnpj { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
}
