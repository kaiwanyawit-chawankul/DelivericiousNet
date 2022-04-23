namespace DelivericiousNet.Core
{
    public record Menu
    {
        public Menu(string name) : this(name, Money.Null()) { }

        public Menu(string name, Money price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public Money Price { get; }
    }
}
