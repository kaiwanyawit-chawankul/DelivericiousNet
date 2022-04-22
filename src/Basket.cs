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
            _menu.Add(menu);
        }

        public int Count()
        {
            return _menu.Count;
        }

        public IReadOnlyCollection<Menu> Items()
        {
            return _menu.AsReadOnly();
        }

        public void Remove(Menu chocolateIceCreams)
        {
            var found = _menu.Where(x => x.Name == chocolateIceCreams.Name).FirstOrDefault();
            if (found != null)
            {
                found.Quantity -= chocolateIceCreams.Quantity;
            }
        }
    }
}
