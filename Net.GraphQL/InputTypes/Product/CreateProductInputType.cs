namespace Net.GraphQL.InputTypes.Product;

public class CreateProductInputType
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
