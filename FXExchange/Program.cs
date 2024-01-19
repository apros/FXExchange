
using Exchange;
using ExchangeLibrary;
using ExchangeLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;

try
{
    // Check if any command-line arguments are provided
    if (args.Length == 0)
    {
        Console.WriteLine("Usage: Exchange <currency pair> <amount to exchange>");
    }
    else
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ICurrencyRateProvider, RatesProvider>()
            .AddSingleton<IInputParsable, ConsoleInputParser>()
            .BuildServiceProvider();

        // Input

        string inputArgs = string.Join(" ", args);

        var parser = serviceProvider.GetRequiredService<IInputParsable>();

        var exchangeArgs = parser.ParseInput(inputArgs);        

        // Create instance of RatesProvider
        var exchangeRates = serviceProvider.GetRequiredService<ICurrencyRateProvider>();

        // Create instance of CurrencyExchange
        var currencyExchange = new CurrencyExchange(exchangeRates.GetRates());       

        // Calculate exchanged amount using the CurrencyExchange class
        decimal exchangedAmount = Decimal.Round(currencyExchange.Exchange(exchangeArgs), 4);

        // Output result
        Console.WriteLine($"Exchanged amount: {exchangedAmount} {exchangeArgs.BaseCurrency}");
    }
}
catch (Exception ex)
{
    // Handle the exception
    Console.WriteLine($"An error occurred: {ex.Message}");

    // Exit the application with a non-zero exit code to indicate an error
    Environment.ExitCode = 1;
}
