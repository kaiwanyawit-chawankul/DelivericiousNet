using System;
using Xunit;

namespace DelivericiousNet.Core.Test
{
    public class BasketRepositoryTests
    {
        [Fact]
        public void ShouldSaveBasketInRepository()
        {
            Basket basket = new Basket();
            BasketRepository basketRepository = new BasketRepository();
            basketRepository.Save(basket);
            var savedBasket = basketRepository.GetBasketById(basket.Id);
            Assert.Equal(basket, savedBasket);
        }

        [Fact]
        public void ShouldNotAbleToSaveBasketInRepositoryIfBasketIsNull()
        {
            Basket basket = null;
            BasketRepository basketRepository = new BasketRepository();
            Assert.Throws<Exception>(() => basketRepository.Save(basket));
        }

        [Fact]
        public void ShouldNotAbleToGetBasketIfBasketIsNotExits()
        {
            Basket basket1 = new Basket();
            Basket basket2 = new Basket();
            BasketRepository basketRepository = new BasketRepository();
            basketRepository.Save(basket1);
            Assert.Null(basketRepository.GetBasketById(basket2.Id));
        }
    }
}