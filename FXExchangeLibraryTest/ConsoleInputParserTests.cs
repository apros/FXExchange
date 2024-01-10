using ExchangeLibrary;
using System.Globalization;

[TestFixture]
public class ConsoleInputParserTests
{
    [Test]
    public void ParseInput_ValidInput_ReturnsExchangeArgs()
    {
        // Arrange
        var parser = new ConsoleInputParser();
        string input = "USD/EUR 100";

        // Act
        var result = parser.ParseInput(input);

        // Assert
        Assert.AreEqual("USD", result.Currency);
        Assert.AreEqual("EUR", result.BaseCurrency);
        Assert.AreEqual(100, result.Amount);
    }

    [Test]
    public void ParseInput_ValidInput_ReturnsExchangeArgs_1_US()
    {
        // Arrange
        var usCulture = CultureInfo.GetCultureInfo("en-US");
        var parser = new ConsoleInputParser(usCulture);
        string input = "USD/EUR 1000000.00";

        // Act
        var result = parser.ParseInput(input);

        // Assert
        Assert.AreEqual("USD", result.Currency);
        Assert.AreEqual("EUR", result.BaseCurrency);
        Assert.AreEqual(1000000.00m, result.Amount);
    }

    [Test]
    public void ParseInput_ValidInput_ReturnsExchangeArgs_2_US()
    {
        // Arrange
        var usCulture = CultureInfo.GetCultureInfo("en-US");
        var parser = new ConsoleInputParser(usCulture);
        string input = "USD/EUR 0.05";

        // Act
        var result = parser.ParseInput(input);

        // Assert
        Assert.AreEqual("USD", result.Currency);
        Assert.AreEqual("EUR", result.BaseCurrency);
        Assert.AreEqual(0.05m, result.Amount);
    }

    [Test]
    public void ParseInput_ValidInput_ReturnsExchangeArgs_1_DK()
    {
        // Arrange
        var dkCulture = CultureInfo.GetCultureInfo("da-DK");
        var parser = new ConsoleInputParser(dkCulture);
        string input = "USD/EUR 1000000,00";

        // Act
        var result = parser.ParseInput(input);

        // Assert
        Assert.AreEqual("USD", result.Currency);
        Assert.AreEqual("EUR", result.BaseCurrency);
        Assert.AreEqual(1000000m, result.Amount);
    }

    [Test]
    public void ParseInput_ValidInput_ReturnsExchangeArgs_2_DK()
    {
        // Arrange
        var dkCulture = CultureInfo.GetCultureInfo("da-DK");
        var parser = new ConsoleInputParser(dkCulture);
        string input = "USD/EUR 0,05";

        // Act
        var result = parser.ParseInput(input);

        // Assert
        Assert.AreEqual("USD", result.Currency);
        Assert.AreEqual("EUR", result.BaseCurrency);
        Assert.AreEqual(0.05m, result.Amount);
    }

    [Test]
    public void ParseInput_InvalidInput_ReturnsExchangeArgs()
    {
        // Arrange
        var parser = new ConsoleInputParser();
        string input = "USD/EUR -100";
        
        // Act and Assert
        Assert.Throws<ArgumentException>(() => parser.ParseInput(input));
    }

    [Test]
    public void ParseInput_InvalidCurrencyPairFormat_ThrowsArgumentException()
    {
        // Arrange
        var parser = new ConsoleInputParser();
        string input = "USDEUR 100";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => parser.ParseInput(input));
    }



    [Test]
    public void ParseInput_InvalidAmountFormat_ThrowsArgumentException()
    {
        // Arrange
        var parser = new ConsoleInputParser();
        string input = "USD/EUR ABC";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => parser.ParseInput(input));
    }

    [Test]
    public void ParseInput_MissingAmount_ThrowsArgumentException()
    {
        // Arrange
        var parser = new ConsoleInputParser();
        string input = "USD/EUR";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => parser.ParseInput(input));
    }

    [Test]
    public void ParseInput_EmptyInput_ThrowsArgumentException()
    {
        // Arrange
        var parser = new ConsoleInputParser();
        string input = string.Empty;

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => parser.ParseInput(input));
    }

    [Test]
    public void ParseInput_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        var parser = new ConsoleInputParser();

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => parser.ParseInput(null));
    }
}
