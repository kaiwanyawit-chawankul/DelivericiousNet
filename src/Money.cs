namespace DelivericiousNet.Core
{
    public record Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public static Money Null()
        {
            return new Money(0, "");
        }

        public static Money SGD(decimal amount)
        {
            return new Money(amount, Core.Currency.SGD);
        }

        public static Money THB(decimal amount)
        {
            return new Money(amount, Core.Currency.THB);
        }
    }
}
