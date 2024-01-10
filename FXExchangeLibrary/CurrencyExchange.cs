using System;
using System.Collections.Generic;

public class CurrencyExchange
{
    private readonly Dictionary<string, decimal> exchangeRates;

    public CurrencyExchange(Dictionary<string, decimal> exchangeRates)
    {
        this.exchangeRates = exchangeRates;
    }

    public decimal Exchange(string currencyPair, decimal amount)
    {
        var currencies = currencyPair.Split('/');
        if (currencies.Length != 2)
        {
            throw new ArgumentException("Invalid currency pair format.");
        }

        string mainCurrency = currencies[0];
        string moneyCurrency = currencies[1];

        if (exchangeRates.ContainsKey(mainCurrency) && exchangeRates.ContainsKey(moneyCurrency))
        {
            if (mainCurrency == moneyCurrency)
            {
                return amount; // Same currencies, return the amount as is
            }
            else
            {
                decimal exchangeRate = exchangeRates[moneyCurrency] / exchangeRates[mainCurrency];
                return amount * exchangeRate;
            }
        }
        else
        {
            throw new ArgumentException("Unknown currency in the pair.");
        }
    }
}
