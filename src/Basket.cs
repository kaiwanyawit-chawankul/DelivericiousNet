using System;
using System.Collections.Generic;
using System.Linq;

namespace DelivericiousNet.Core
{
    public class Basket
    {
        private List<Menu> _menu = new List<Menu>();

        public void Add(Menu menu)
        {
            var found = _menu.Where(x => x.Name == menu.Name).FirstOrDefault();
            if (found == null)
            {
                _menu.Add(
                    new Menu(
                        menu.Name,
                        new Money(menu.Price.Amount, menu.Price.Currency),
                        menu.Quantity
                    )
                );
            }
            else
            {
                found.Quantity += menu.Quantity;
            }
        }

        public int Count()
        {
            return _menu.Count;
        }

        public IReadOnlyCollection<Menu> Items()
        {
            return _menu.AsReadOnly();
        }

        public decimal Total()
        {
            return _menu.Sum(x => x.Price.Amount * x.Quantity);
        }

        public void Remove(Menu chocolateIceCreams)
        {
            var found = _menu.Where(x => x.Name == chocolateIceCreams.Name).FirstOrDefault();
            if (found != null)
            {
                found.Quantity -= chocolateIceCreams.Quantity;
                if (found.Quantity == 0)
                    _menu.Remove(found);
            }
        }

        public Basket Copy()
        {
            var newBasket = new Basket();
            foreach (var item in _menu)
            {
                newBasket.Add(item);
            }
            return newBasket;
        }
    }
}
