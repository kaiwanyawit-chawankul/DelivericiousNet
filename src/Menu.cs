namespace DelivericiousNet.Core
{
    public class Menu
    {
        public Menu(string name) : this(name, 0, 1, "SGD")
        {
            Name = name;
        }

        public Menu(string name, int cost, int quantity = 1, string currency = "SGD")
        {
            Name = name;
            Cost = cost;
            Quantity = quantity;
            Currency = currency;
        }

        public string Name { get; }
        public int Cost { get; }
        public int Quantity { get; }
        public string Currency { get; }
    }
}
