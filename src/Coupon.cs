namespace DelivericiousNet.Core
{
    public record Coupon
    {
        public string Name { get; }
        public decimal DiscountPercent { get; }

        public Coupon(string name, decimal discountPercent)
        {
            Name = name;
            DiscountPercent = discountPercent;
        }
    }
}