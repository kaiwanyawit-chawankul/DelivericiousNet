using Xunit;

namespace DelivericiousNet.Core.Test
{
    public class MoneyTests
    {
        [Fact]
        public void MoneyWithSameAmountAndCurrencyShouldBeEqual()
        {
            var money = Money.SGD(10);
            Assert.Equal(Money.SGD(10), Money.SGD(10));
        }
    }
}
