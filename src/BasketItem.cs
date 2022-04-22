namespace DelivericiousNet.Core
{
    public class BasketItem
    {
        public BasketItem(Menu menu) : this(menu, 1) { }

        public BasketItem(Menu menu, int quantity)
        {
            Menu = menu;
            Quantity = quantity;
        }

        public Menu Menu { get; }
        public int Quantity { get; set; }
    }
}
