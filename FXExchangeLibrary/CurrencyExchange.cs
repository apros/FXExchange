using ExchangeLibrary.Models;

// Represents a class responsible for currency exchange calculations based on provided exchange rates.
public class CurrencyExchange
{
    // List of exchange rates used for currency conversion.
    private IList<Rate> exchangeRates;

    // Initializes a new instance of the CurrencyExchange class with the specified exchange rates.
    // Throws ArgumentNullException if exchangeRates is null.
    public CurrencyExchange(IList<Rate> exchangeRates)
    {
        if (exchangeRates == null)
        {
            throw new ArgumentNullException(nameof(exchangeRates), "Exchange rates are not set.");
        }

        this.exchangeRates = exchangeRates;
    }

    // Performs currency exchange based on the provided ExchangeArgs.
    // Throws ArgumentNullException if exchangeArgs is null.
    // Throws ArgumentException if no matching exchange rates are found for the specified currencies.
    public decimal Exchange(ExchageArgs exchangeArgs)
    {
        if (exchangeArgs == null)
        {
            throw new ArgumentNullException(nameof(exchangeArgs));
        }

        // If the base currency is the same as the target currency, no conversion needed.
        if (exchangeArgs.BaseCurrency == exchangeArgs.Currency)
        {
            return exchangeArgs.Amount;
        }

        decimal valueInBaseCurrency = 0m;

        // Iterate through exchange rates to find a match for converting to the target currency.
        foreach (var rate in exchangeRates)
        {
            if (rate.BaseCurrency.CurrencyCode == "DKK" && rate.Currency.CurrencyCode == exchangeArgs.Currency)
            {
                // Calculate the value in the base currency using the exchange rate.
                valueInBaseCurrency = (exchangeArgs.Amount * rate.ExchangeRate) / 100m;

                // If the base currency is "DKK," return the rounded result.
                if (exchangeArgs.BaseCurrency == "DKK")
                {
                    return Decimal.Round(valueInBaseCurrency, 4);
                }
            }
        }

        // Iterate through exchange rates to find a match for converting from the base currency.
        foreach (var rate in exchangeRates)
        {
            if (rate.BaseCurrency.CurrencyCode == "DKK" && rate.Currency.CurrencyCode == exchangeArgs.BaseCurrency)
            {
                // Adjust the value based on the reverse exchange rate.
                valueInBaseCurrency = valueInBaseCurrency / (rate.ExchangeRate / 100m);

                // Return the rounded result after the conversion.
                return Decimal.Round(valueInBaseCurrency, 4);
            }
        }

        // Handle cases where no matching rates are found for the specified currencies.
        throw new ArgumentException("Exchange rates not found for the specified currencies.");
    }
}
