namespace DelivericiousNet.Core
{
    public class Menu
    {
        public Menu(string name) : this(name, Money.Null(), 1)
        {
            Name = name;
        }

        public Menu(string name, Money price, int quantity = 1)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; }
        public Money Price { get; }
        public int Quantity { get; set; }
    }
}
