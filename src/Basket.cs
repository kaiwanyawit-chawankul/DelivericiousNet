using System;
using System.Collections.Generic;
using System.Linq;

namespace DelivericiousNet.Core
{
    public class Basket
    {
        private const int BASKET_LIMIT = 100;
        public static readonly Coupon DELIVERICIOUS_10 = new Coupon("DELIVERICIOUS_10", 10);
        public Guid Id { get; }
        private readonly List<BasketItem> _items = new();
        private List<Coupon> _coupons = new List<Coupon>();

        public Basket() : this(Guid.NewGuid()) { }

        public Basket(Guid id)
        {
            Id = id;
        }

        public void Add(BasketItem basketItem)
        {
            if (GetBasketQuantity() + basketItem.Quantity > BASKET_LIMIT)
            {
                throw new BasketQuantityExceedException(BASKET_LIMIT);
            }

            var found = _items.FirstOrDefault(x => x.Menu.Name == basketItem.Menu.Name);
            if (found == null)
            {
                _items.Add(basketItem);
                PopulateCoupon();
            }
            else
            {
                found.Quantity += basketItem.Quantity;
            }
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
            if (found == null)
                return;
            found.Quantity -= quantity;
            if (found.Quantity == 0)
            {
                _items.Remove(found);
                PopulateCoupon();
            }
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

        public List<Coupon> AvailableCoupons()
        {
            return _coupons;
        }

        private void PopulateCoupon()
        {
            _coupons.Clear();
            var count = _items.Where(item => item.Menu.MenuType == MenuType.SOUP).Sum((item) => item.Quantity);
            if (count >= 5 && !_coupons.Contains(DELIVERICIOUS_10))
            {
                _coupons.Add(DELIVERICIOUS_10);
            }
        }
    }
}