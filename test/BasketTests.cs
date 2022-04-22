using System.Linq;
using Xunit;

namespace DelivericiousNet.Core.Test
{
    public class BasketTests
    {
        [Fact]
        public void WhenAddItemCount_ShouldIncreaseItemCount()
        {
            Basket basket = new Basket();
            var tomatoSoup = new Menu("Tomato soup");
            var tomatoSoupBasketItem = new BasketItem(tomatoSoup);
            basket.Add(tomatoSoupBasketItem);
            Assert.Equal(1, basket.Items().Count);
        }

        [Fact]
        public void WhenAddTomatoSoup_ShouldFound()
        {
            Basket basket = new Basket();
            var tomatoSoup = new Menu("Tomato soup");
            var tomatoSoupBasketItem = new BasketItem(tomatoSoup);
            basket.Add(tomatoSoupBasketItem);
            Assert.Equal("Tomato soup", basket.Items().First().Menu.Name);
        }

        [Fact]
        public void WhenAddSeafoodSaladWithCostPrice12SGD_ShouldFound()
        {
            Basket basket = new Basket();
            var seaFoodSalad = new Menu("Sea food Salad", Money.SGD(12));
            var seaFoodSaladBasketItem = new BasketItem(seaFoodSalad);
            basket.Add(seaFoodSaladBasketItem);
            Assert.Equal(seaFoodSalad.Name, basket.Items().First().Menu.Name);
            Assert.Equal(seaFoodSalad.Price.Amount, basket.Items().First().Menu.Price.Amount);
            Assert.Equal(seaFoodSalad.Price.Currency, basket.Items().First().Menu.Price.Currency);
        }

        [Fact]
        public void WhenAdd3ChocolateIceCreamWithPrice4SGD_ShouldFound()
        {
            Basket basket = new Basket();
            var chocolateIceCreams = new Menu("Chocolate Ice Cream", Money.SGD(4));
            var chocolateIceCreamsBasketItem = new BasketItem(chocolateIceCreams, 3);
            basket.Add(chocolateIceCreamsBasketItem);
            Assert.Equal(chocolateIceCreams.Name, basket.Items().First().Menu.Name);
            Assert.Equal(chocolateIceCreams.Price.Amount, basket.Items().First().Menu.Price.Amount);
            Assert.Equal(
                chocolateIceCreams.Price.Currency,
                basket.Items().First().Menu.Price.Currency
            );
            Assert.Equal(3, basket.Items().First().Quantity);
        }

        [Fact]
        public void WhenRemoveChocolateIceCream_ShouldNotBeFound()
        {
            Basket basket = new Basket();
            var chocolateIceCreams = new Menu("Chocolate Ice Cream", Money.SGD(4));
            var chocolateIceCreamsBasketItem = new BasketItem(chocolateIceCreams, 3);
            basket.Add(chocolateIceCreamsBasketItem);
            basket.Remove(chocolateIceCreams);
            Assert.Equal(2, basket.Items().First().Quantity);
        }

        [Fact]
        public void WhenCopy_ShouldHaveACopy()
        {
            Basket basket = new Basket();
            var chocolateIceCreams = new Menu("Chocolate Ice Cream", Money.SGD(4));
            var seaFoodSalad = new Menu("Sea food Salad", Money.SGD(12));
            var chocolateIceCreamsBasketItem = new BasketItem(chocolateIceCreams, 3);
            var seaFoodSaladBasketItem = new BasketItem(seaFoodSalad);
            basket.Add(chocolateIceCreamsBasketItem);
            basket.Add(seaFoodSaladBasketItem);
            var result = basket.Copy();
            var items = basket.Items().ToList();
            var resultItems = result.Items().ToList();
            Assert.NotEqual(result.GetBasketId(), basket.GetBasketId());
            
            for (var i = 0; i < items.Count; i++)
            {
                Assert.Equal(resultItems[i].Menu.Name, items[i].Menu.Name);
                Assert.Equal(resultItems[i].Menu.Price.Amount, items[i].Menu.Price.Amount);
                Assert.Equal(resultItems[i].Menu.Price.Currency, items[i].Menu.Price.Currency);
                Assert.Equal(resultItems[i].Quantity, items[i].Quantity);
            }
        }

        [Fact]
        public void WhenGetTotal_ShouldCorrect()
        {
            Basket basket = new Basket();
            var chocolateIceCreams = new Menu("Chocolate Ice Cream", Money.SGD(4));
            var seaFoodSalad = new Menu("Sea food Salad", Money.SGD(12));
            var chocolateIceCreamsBasketItem = new BasketItem(chocolateIceCreams, 3);
            var seaFoodSaladBasketItem = new BasketItem(seaFoodSalad);
            basket.Add(chocolateIceCreamsBasketItem);
            basket.Add(seaFoodSaladBasketItem);
            Assert.Equal(24, basket.Total());
        }
    }
}
