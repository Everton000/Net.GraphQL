namespace Net.GraphQL.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public virtual ICollection<Order>? Orders { get; set; }
}
