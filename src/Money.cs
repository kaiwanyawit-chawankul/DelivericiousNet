namespace DelivericiousNet.Core
{
    public class Money
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
            return new Money(amount, "SGD");
        }
    }
}
