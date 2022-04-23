using System;
using System.Collections.Generic;

namespace DelivericiousNet.Core
{
    public class BasketRepository
    {
        private Dictionary<Guid, Basket> _baskets = new Dictionary<Guid, Basket>();
        public void Add(Basket basket)
        {
            if (basket == null)
            {
                throw new Exception();
            }
            if (!CheckBasketExistsById(basket.Id))
            {
                _baskets.Add(basket.Id, basket);
            }
        }
        
        public Basket GetBasket(Basket basket)
        {
            if (!CheckBasketExistsById(basket.Id))
            {
                return null;
            }
            return _baskets[basket.Id];
        }

        private bool CheckBasketExistsById(Guid id)
        {
            return _baskets.ContainsKey(id);
        }
    }
}