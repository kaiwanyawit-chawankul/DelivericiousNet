namespace DelivericiousNet.Core
{
    public record Menu
    {
        public Menu(string name) : this(name, Money.Null(), MenuType.ANY) { }

        public Menu(string name, Money price, MenuType menuType = MenuType.ANY)
        {
            MenuType = menuType;
            Name = name;
            Price = price;
        }

        public MenuType MenuType { get; }
        public string Name { get; }
        public Money Price { get; }
    }
}