using ExchangeLibrary.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class CurrencyExchangeTests
{
    [Test]
    public void Exchange_SameCurrencies_ReturnsSameAmount()
    {
        // Arrange
        var exchangeRates = new List<Rate> { new Rate() { BaseCurrency=new Currency() { CurrencyCode = "DKK" }, Currency= new Currency() { CurrencyCode = "USD" }, ExchangeRate = 1m }};
        var currencyExchange = new CurrencyExchange(exchangeRates);
        var exchangeArgs = new ExchageArgs("USD", "USD", 100);

        // Act
        decimal result = currencyExchange.Exchange(exchangeArgs);

        // Assert
        Assert.AreEqual(100, result);
    }

    [Test]
    public void Exchange_ValidExchange_ReturnsCorrectAmount()
    {
        // Arrange
        var exchangeRates = new List<Rate> { new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "USD" }, ExchangeRate = 7.5m } }; 
        var currencyExchange = new CurrencyExchange(exchangeRates);
        var exchangeArgs = new ExchageArgs( "USD","DKK", 100);

        // Act
        decimal result = currencyExchange.Exchange(exchangeArgs);

        // Assert
        Assert.AreEqual(750, result);
    }

    [Test]
    public void Exchange_ValidExchange_ReturnsCorrectAmount_NotDkk()
    {
        // Arrange
        var exchangeRates = new List<Rate> { 
            new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }
                        , Currency = new Currency() { CurrencyCode = "USD" }
                        , ExchangeRate = 663.11m },
            new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }
                        , Currency = new Currency() { CurrencyCode = "EUR" }
                        , ExchangeRate = 743.94m }
        };
        var currencyExchange = new CurrencyExchange(exchangeRates);
        var exchangeArgs = new ExchageArgs( "EUR","USD", 1);

        // Act
        decimal result = currencyExchange.Exchange(exchangeArgs);

        // Assert
        Assert.AreEqual(1.1219m, result);
    }

    [Test]
    public void Exchange_ValidExchange_ReturnsCorrectAmount_NotDkk_2()
    {
        // Arrange
        var exchangeRates = new List<Rate> {
            new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }
                        , Currency = new Currency() { CurrencyCode = "USD" }
                        , ExchangeRate = 663.11m },
            new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }
                        , Currency = new Currency() { CurrencyCode = "EUR" }
                        , ExchangeRate = 743.94m }
        };
        var currencyExchange = new CurrencyExchange(exchangeRates);
        var exchangeArgs = new ExchageArgs( "USD","EUR", 1);

        // Act
        decimal result = currencyExchange.Exchange(exchangeArgs);

        // Assert
        Assert.AreEqual(0.8913m, result);
    }

    [Test]
    public void Exchange_InvalidExchangeRates_ThrowsArgumentException()
    {
        // Arrange
        //var currencyExchange = new CurrencyExchange(null);
        var exchangeArgs = new ExchageArgs( "EUR","USD", 100);

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => new CurrencyExchange(null));
    }

    [Test]
    public void Exchange_MissingExchangeRates_ThrowsArgumentException()
    {
        // Arrange
        var currencyExchange = new CurrencyExchange(new List<Rate>());
        var exchangeArgs = new ExchageArgs( "EUR","USD", 100);

        // Act and Assert
        Assert.Throws<ArgumentException>(() => currencyExchange.Exchange(exchangeArgs));
    }

    [Test]
    public void Exchange_InvalidCurrencyPair_ThrowsArgumentException()
    {
        // Arrange
        var exchangeRates = new List<Rate> { new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "USD" }, ExchangeRate = 7.5m } };
        var currencyExchange = new CurrencyExchange(exchangeRates);
        var exchangeArgs = new ExchageArgs( "USD","USDEUR", 100);

        // Act and Assert
        Assert.Throws<ArgumentException>(() => currencyExchange.Exchange(exchangeArgs));
    }

    // Add more test cases for different scenarios
}
