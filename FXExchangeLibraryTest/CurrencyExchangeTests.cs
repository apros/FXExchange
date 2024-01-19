using ExchangeLibrary.Models;

[TestFixture]
public class CurrencyExchangeTests
{
    [Test]
    public void Exchange_SameCurrencies_ReturnsSameAmount()
    {
        // Arrange
        //var exchangeRates = new Dictionary<string, Rate> { new KeyValuePair<string, Rate>("USD", new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "USD" }, ExchangeRate = 1m }) };

        var exchangeRates = new Dictionary<string, Rate>
        {
            { "USD", new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "USD" }, ExchangeRate = 1m } }
        };

        var currencyExchange = new CurrencyExchange(exchangeRates);
        var exchangeArgs = new ExchageArgs("USD", "USD", 100);

        // Act
        decimal result = Decimal.Round(currencyExchange.Exchange(exchangeArgs), 4);

        // Assert
        Assert.That(result, Is.EqualTo(100));
    }

    [Test]
    public void Exchange_ValidExchange_ReturnsCorrectAmount()
    {
        // Arrange
        //var exchangeRates = new List<Rate> { new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "USD" }, ExchangeRate = 7.5m } };
        var exchangeRates = new Dictionary<string, Rate>
        {
            { "USD", new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "USD" }, ExchangeRate = 7.5m } }
        };
        var currencyExchange = new CurrencyExchange(exchangeRates);
        var exchangeArgs = new ExchageArgs( "USD","DKK", 100);

        // Act
        decimal result = Decimal.Round(currencyExchange.Exchange(exchangeArgs), 4 );

        // Assert
        Assert.That(result, Is.EqualTo(7.5));
    }

    [Test]
    public void Exchange_ValidExchange_ReturnsCorrectAmount_NotDkk()
    {
        // Arrange
        //var exchangeRates = new List<Rate> { 
        //    new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }
        //                , Currency = new Currency() { CurrencyCode = "USD" }
        //                , ExchangeRate = 663.11m },
        //    new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }
        //                , Currency = new Currency() { CurrencyCode = "EUR" }
        //                , ExchangeRate = 743.94m }
        //};
        var exchangeRates = new Dictionary<string, Rate>
        {
            { "USD", new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "USD" }, ExchangeRate = 663.11m } },
             { "EUR", new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "EUR" }, ExchangeRate = 743.94m } }
        };
        var currencyExchange = new CurrencyExchange(exchangeRates);
        var exchangeArgs = new ExchageArgs( "EUR","USD", 1);

        // Act
        decimal result = Decimal.Round(currencyExchange.Exchange(exchangeArgs),4);

        // Assert
        Assert.That(result, Is.EqualTo(1.1219m));
    }

    [Test]
    public void Exchange_ValidExchange_ReturnsCorrectAmount_NotDkk_2()
    {
        // Arrange
        //var exchangeRates = new List<Rate> {
        //    new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }
        //                , Currency = new Currency() { CurrencyCode = "USD" }
        //                , ExchangeRate = 663.11m },
        //    new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }
        //                , Currency = new Currency() { CurrencyCode = "EUR" }
        //                , ExchangeRate = 743.94m }
        //};
        var exchangeRates = new Dictionary<string, Rate>
        {
            { "USD", new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "USD" }, ExchangeRate = 663.11m } },
             { "EUR", new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "EUR" }, ExchangeRate = 743.94m } }
        };
        var currencyExchange = new CurrencyExchange(exchangeRates);
        var exchangeArgs = new ExchageArgs( "USD","EUR", 1);

        // Act
        decimal result = Decimal.Round(currencyExchange.Exchange(exchangeArgs), 4);

        // Assert
        Assert.That(result, Is.EqualTo(0.8913m));
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
        var currencyExchange = new CurrencyExchange(new Dictionary<string,Rate>());
        var exchangeArgs = new ExchageArgs( "EUR","USD", 100);

        // Act and Assert
        Assert.Throws<ArgumentException>(() => currencyExchange.Exchange(exchangeArgs));
    }

    [Test]
    public void Exchange_InvalidCurrencyPair_ThrowsArgumentException()
    {
        // Arrange
        //var exchangeRates = new List<Rate> { new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "USD" }, ExchangeRate = 7.5m } };
        var exchangeRates = new Dictionary<string, Rate>
        {
            { "USD", new Rate() { BaseCurrency = new Currency() { CurrencyCode = "DKK" }, Currency = new Currency() { CurrencyCode = "USD" }, ExchangeRate = 7.5m } }
        };
        var currencyExchange = new CurrencyExchange(exchangeRates);
        var exchangeArgs = new ExchageArgs( "USD","USDEUR", 100);

        // Act and Assert
        Assert.Throws<ArgumentException>(() => currencyExchange.Exchange(exchangeArgs));
    }

}
