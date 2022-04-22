using System.Collections.Generic;

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
    }
}
