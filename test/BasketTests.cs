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
            basket.Add(new Menu("Tomato soup"));
            Assert.Equal(1, basket.Items().Count);
        }

        [Fact]
        public void WhenAddTomatoSoup_ShouldFound()
        {
            Basket basket = new Basket();
            basket.Add(new Menu("Tomato soup"));
            Assert.Equal("Tomato soup", basket.Items().First().Name);
        }

        [Fact]
        public void WhenAddSeafoodSaladWithCostPrice12SGD_ShouldFound()
        {
            Basket basket = new Basket();
            var seaFoodSalad = new Menu("Sea food Salad", Money.SGD(12));
            basket.Add(seaFoodSalad);
            Assert.Equal(seaFoodSalad.Name, basket.Items().First().Name);
            Assert.Equal(seaFoodSalad.Price.Amount, basket.Items().First().Price.Amount);
            Assert.Equal(seaFoodSalad.Price.Currency, basket.Items().First().Price.Currency);
        }

        [Fact]
        public void WhenAdd3ChocolateIceCreamWithPrice4SGD_ShouldFound()
        {
            Basket basket = new Basket();
            var chocolateIceCreams = new Menu("Chocolate Ice Cream", Money.SGD(4), 3);
            basket.Add(chocolateIceCreams);
            Assert.Equal(chocolateIceCreams.Name, basket.Items().First().Name);
            Assert.Equal(chocolateIceCreams.Price.Amount, basket.Items().First().Price.Amount);
            Assert.Equal(chocolateIceCreams.Price.Currency, basket.Items().First().Price.Currency);
            Assert.Equal(chocolateIceCreams.Quantity, basket.Items().First().Quantity);
        }

        [Fact]
        public void WhenRemoveChocolateIceCream_ShouldNotBeFound()
        {
            Basket basket = new Basket();
            var chocolateIceCreams = new Menu("Chocolate Ice Cream", Money.SGD(4), 3);
            basket.Add(chocolateIceCreams);
            var itemToRemove = new Menu("Chocolate Ice Cream");
            basket.Remove(itemToRemove);
            Assert.Equal(2, basket.Items().First().Quantity);
        }

        [Fact]
        public void WhenCopy_ShouldHaveACopy()
        {
            Basket basket = new Basket();
            var chocolateIceCreams = new Menu("Chocolate Ice Cream", Money.SGD(4), 3);
            var seaFoodSalad = new Menu("Sea food Salad", Money.SGD(12));
            basket.Add(chocolateIceCreams);
            basket.Add(seaFoodSalad);
            var result = basket.Copy();
            var items = basket.Items().ToList();
            var resultItems = result.Items().ToList();
            Assert.NotEqual(result, basket);

            for (var i = 0; i < items.Count; i++)
            {
                Assert.Equal(resultItems[i].Name, items[i].Name);
                Assert.Equal(resultItems[i].Price.Amount, items[i].Price.Amount);
                Assert.Equal(resultItems[i].Price.Currency, items[i].Price.Currency);
                Assert.Equal(resultItems[i].Quantity, items[i].Quantity);
            }
        }

        [Fact]
        public void WhenGetTotal_ShouldCorrect()
        {
            Basket basket = new Basket();
            var chocolateIceCreams = new Menu("Chocolate Ice Cream", Money.SGD(4), 3);
            var seaFoodSalad = new Menu("Sea food Salad", Money.SGD(12));
            basket.Add(chocolateIceCreams);
            basket.Add(seaFoodSalad);
            Assert.Equal(24, basket.Total());
        }
    }
}
