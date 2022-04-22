using System;
using System.Collections.Generic;
using System.Linq;

namespace DelivericiousNet.Core
{
    public class Basket
    {
        private List<BasketItem> _items = new List<BasketItem>();

        public void Add(Menu menu)
        {
            Add(menu, 1);
        }

        public void Add(Menu menu, int quantity)
        {
            var found = _items.Where(x => x.Menu.Name == menu.Name).FirstOrDefault();
            if (found == null)
            {
                _items.Add(new BasketItem(menu, quantity));
            }
            else
            {
                found.Quantity += quantity;
            }
        }

        public int Count()
        {
            return _items.Count;
        }

        public IReadOnlyCollection<BasketItem> Items()
        {
            return _items.AsReadOnly();
        }

        public decimal Total()
        {
            return _items.Sum(x => x.Menu.Price.Amount * x.Quantity);
        }

        public void Remove(Menu menu)
        {
            Remove(menu, 1);
        }

        public void Remove(Menu menu, int quantity)
        {
            var found = _items.Where(x => x.Menu.Name == menu.Name).FirstOrDefault();
            if (found != null)
            {
                found.Quantity -= quantity;
                if (found.Quantity == 0)
                    _items.Remove(found);
            }
        }

        public Basket Copy()
        {
            var newBasket = new Basket();
            foreach (var item in _items)
            {
                newBasket.Add(item.Menu, item.Quantity);
            }
            return newBasket;
        }
    }
}
