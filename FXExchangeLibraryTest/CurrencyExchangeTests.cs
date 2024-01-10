using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class CurrencyExchangeTests
{
    [Test]
    public void Exchange_SameCurrencies_ReturnsSameAmount()
    {
        // Arrange
        var exchangeRates = new Dictionary<string, decimal> { { "USD", 1.0m } };
        var currencyExchange = new CurrencyExchange(exchangeRates);

        // Act
        decimal result = currencyExchange.Exchange("USD/USD", 100);

        // Assert
        Assert.AreEqual(100, result);
    }

    // Add more test cases for different scenarios
}
