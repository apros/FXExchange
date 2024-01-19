using ExchangeLibrary.Interfaces;
using ExchangeLibrary.Models;

namespace Exchange
{
    internal class RatesProvider : ICurrencyRateProvider
    {
        private List<Currency> countries;
        private Dictionary<string,Rate> exchangeRates;

        public RatesProvider()
        {
            countries = new List<Currency>
            {
                { new Currency() {Name = "Danish Krone", CurrencyCode = "DKK" } },
                { new Currency() {Name = "Euro", CurrencyCode = "EUR" } },
                { new Currency() {Name = "US Dollar", CurrencyCode = "USD" } },
                { new Currency() {Name = "Pound sterling", CurrencyCode = "GBP" } },
                { new Currency() {Name = "Swedish Krona", CurrencyCode = "SEK" } },
                { new Currency() {Name = "Norwegian Krone", CurrencyCode = "NOK" } },
                { new Currency() {Name = "Swiss Franc", CurrencyCode = "CHF" } },
                { new Currency() {Name = "Japanese Yen", CurrencyCode = "JPY" } }
            };

            exchangeRates = new Dictionary<string, Rate>
            {
                { countries[1].CurrencyCode, new Rate() { BaseCurrency = countries[0], Currency = countries[1], ExchangeRate = 743.94m } },
                { countries[2].CurrencyCode, new Rate() { BaseCurrency = countries[0], Currency = countries[2], ExchangeRate = 663.11m } },
                { countries[3].CurrencyCode, new Rate() { BaseCurrency = countries[0], Currency = countries[3], ExchangeRate = 852.85m } },
                { countries[4].CurrencyCode, new Rate() { BaseCurrency = countries[0], Currency = countries[4], ExchangeRate = 76.10m } },
                { countries[5].CurrencyCode, new Rate() { BaseCurrency = countries[0], Currency = countries[5], ExchangeRate = 78.40m } },
                { countries[6].CurrencyCode, new Rate() { BaseCurrency = countries[0], Currency = countries[6], ExchangeRate = 683.58m } },
                { countries[7].CurrencyCode, new Rate() { BaseCurrency = countries[0], Currency = countries[7], ExchangeRate = 5.9740m } }
            };  
        }
        
        public IDictionary<string, Rate> GetRates()
        {
            
            return exchangeRates;
        }
    }
}
