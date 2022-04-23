using System;

namespace DelivericiousNet.Core
{
    public class BasketQuantityExceedException : Exception
    {
        private int Limit;

        public BasketQuantityExceedException(int limit) : base("You are already exceed the basket quantity")
        {
            this.Limit = limit;
        }
    }
}
