namespace DelivericiousNet.Core;

public class Menu
{
    public Menu(string name)
    {
        Name = name;
    }

    public Menu(string name, int cost, int quantity = 1)
    {
        Name = name;
        Cost = cost;
        Quantity = quantity;
    }

    public string Name { get; }
    public int Cost { get; }
    public int Quantity { get; }
}
