using ExchangeLibrary.Models;

// Represents a class responsible for currency exchange calculations based on provided exchange rates.
public class CurrencyExchange
{
    // List of exchange rates used for currency conversion.
    private IDictionary<string, Rate> exchangeRates;

    // Initializes a new instance of the CurrencyExchange class with the specified exchange rates.
    // Throws ArgumentNullException if exchangeRates is null.
    public CurrencyExchange(IDictionary<string, Rate> exchangeRates)
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

        // Seek through exchange rates to find a match for converting to the target currency.
        
        if (!exchangeRates.ContainsKey(exchangeArgs.Currency)) throw new ArgumentException("Exchange rates not found for the specified currencies.");
            valueInBaseCurrency = exchangeArgs.Amount * exchangeRates[exchangeArgs.Currency].ExchangeRate / 100m;
        

        // If the base currency is "DKK," return the rounded result.
        if (exchangeArgs.BaseCurrency == "DKK")
        {
            return valueInBaseCurrency;
        }
        //}
        //}
        if (!exchangeRates.ContainsKey(exchangeArgs.BaseCurrency)) throw new ArgumentException("Exchange rates not found for the specified currencies.");

        // Seek through exchange rates to find a match for converting from the base currency.       
        valueInBaseCurrency = valueInBaseCurrency / (exchangeRates[exchangeArgs.BaseCurrency].ExchangeRate / 100m);

        // Return the rounded result after the conversion.
        return valueInBaseCurrency;        

        // Handle cases where no matching rates are found for the specified currencies.
        throw new ArgumentException("Exchange rates not found for the specified currencies.");
    }
}
