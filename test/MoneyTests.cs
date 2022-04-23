using Xunit;

namespace DelivericiousNet.Core.Test
{
    public class MoneyTests
    {
        [Fact]
        public void MoneyWithSameAmountAndCurrencyShouldBeEqual()
        {
            Assert.Equal(Money.SGD(10), Money.SGD(10));
        }

        [Fact]
        public void MoneyWithDiffentAmountAndCurrencyShouldNoBeEqual()
        {
            Assert.NotEqual(Money.SGD(11), Money.SGD(10));
        }

        [Fact]
        public void MoneyWithDiffentCurrencyShouldNoBeEqual()
        {
            Assert.NotEqual(Money.THB(10), Money.SGD(10));
        }
    }
}
