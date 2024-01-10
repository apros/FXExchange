// Exchange rates
Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>
        {
            { "EUR", 743.94m },
            { "USD", 663.11m },
            { "GBP", 852.85m },
            { "SEK", 76.10m },
            { "NOK", 78.40m },
            { "CHF", 683.58m },
            { "JPY", 5.9740m }
        };

// Create instance of CurrencyExchange
var currencyExchange = new CurrencyExchange(exchangeRates);

// Input
Console.Write("Enter ISO currency pair (e.g., EUR/USD): ");
string currencyPair = Console.ReadLine().ToUpper();

Console.Write("Enter amount: ");
if (decimal.TryParse(Console.ReadLine(), out decimal amount))
{
    // Calculate exchanged amount using the CurrencyExchange class
    decimal exchangedAmount = currencyExchange.Exchange(currencyPair, amount);

    // Output result
    Console.WriteLine($"Exchanged amount: {exchangedAmount} DKK");
}
else
{
    Console.WriteLine("Invalid amount entered.");
}
    