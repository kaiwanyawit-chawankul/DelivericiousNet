using System;

namespace DelivericiousNet.Core
{
    public class BasketQuantityExceedException : Exception
    {
        private int Limit;

        public BasketQuantityExceedException(int limt)
        {
            this.Limit = limt;
        }
    }
}
