namespace DelivericiousNet.Core
{
    public class CheckoutService
    {
        public void Checkout(Basket basket)
        {
            //Payment.pay();
            basket.CheckoutCompleted();
        }
    }
}