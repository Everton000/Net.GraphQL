namespace Net.GraphQL.InputTypes.Order;

public class CreateOrderInputType
{
    public int IdClient { get; set; }
    public int[] IdsProducts { get; set; } = [];
}
