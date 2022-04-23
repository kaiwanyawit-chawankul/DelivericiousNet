using System;
using System.Collections.Generic;

namespace DelivericiousNet.Core
{
    public class BasketRepository
    {
        private Dictionary<Guid, Basket> _baskets = new Dictionary<Guid, Basket>();
        public void Save(Basket basket)
        {
            if (basket == null)
            {
                throw new Exception();
            }
            if (!IsBasketExists(basket.Id))
            {
                _baskets.Add(basket.Id, basket);
            }
        }
        
        public Basket GetBasketById(Guid id)
        {
            if (!IsBasketExists(id))
            {
                return null;
            }
            return _baskets[id];
        }

        private bool IsBasketExists(Guid id)
        {
            return _baskets.ContainsKey(id);
        }
    }
}