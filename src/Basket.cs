using System;
using System.Collections.Generic;
using System.Linq;

namespace DelivericiousNet.Core
{
    public class Basket
    {
        private const int BASKET_LIMIT = 100;
        private readonly Guid _id;
        private readonly List<BasketItem> _items = new();
        public Basket() : this(Guid.NewGuid()){}
        
        public Basket(Guid id)
        {
            _id = id;
        }

        public void Add(BasketItem basketItem)
        {
            if (GetBasketQuantity() + basketItem.Quantity > BASKET_LIMIT)
            {
                throw new Exception("You are already exceed the basket quantity");
            }
            
            var found = _items.FirstOrDefault(x => x.Menu.Name == basketItem.Menu.Name);
            if (found == null)
            {
                _items.Add(basketItem);
            }
            else
            {
                found.Quantity += basketItem.Quantity;
            }
        }

        public Guid GetBasketId()
        {
            return _id;
        }

        private int GetBasketQuantity()
        {
            return _items.Sum((item => item.Quantity));
        }

        public IReadOnlyCollection<BasketItem> Items()
        {
            return _items.AsReadOnly();
        }

        public decimal Total()
        {
            return _items.Sum(x => x.Menu.Price.Amount * x.Quantity);
        }

        public void Remove(Menu menu, int quantity = 1)
        {
            var found = _items.FirstOrDefault(x => x.Menu.Name == menu.Name);
            if (found == null) return;
            found.Quantity -= quantity;
            if (found.Quantity == 0)
                _items.Remove(found);
        }

        public Basket Copy()
        {
            var newBasket = new Basket();
            foreach (var item in _items)
            {
                newBasket.Add(item);
            }
            return newBasket;
        }
    }
}
