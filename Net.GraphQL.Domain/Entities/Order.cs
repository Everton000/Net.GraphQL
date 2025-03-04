namespace Net.GraphQL.Domain.Entities;

public class Order : BaseEntity
{
    public required Guid Code { get; set; }
    public required int IdClient { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
}
