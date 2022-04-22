using System.Linq;
using DelivericiousNet.Core;
using Xunit;

namespace DelivericiousNet.Core.Test;

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
        var seaFoodSalad = new Menu("Sea food Salad", 12);
        basket.Add(seaFoodSalad);
        Assert.Equal(seaFoodSalad.Name, basket.Items().First().Name);
        Assert.Equal(seaFoodSalad.Cost, basket.Items().First().Cost);
    }

    [Fact]
    public void WhenAdd3ChocolateIceCreamWithPrice4SGD_ShouldFound()
    {
        Basket basket = new Basket();
        var chocolateIceCreams = new Menu("Chocolate Ice Cream", 4, 3);
        basket.Add(chocolateIceCreams);
        Assert.Equal(chocolateIceCreams.Name, basket.Items().First().Name);
        Assert.Equal(chocolateIceCreams.Cost, basket.Items().First().Cost);
        Assert.Equal(chocolateIceCreams.Quantity, basket.Items().First().Quantity);
    }
}
