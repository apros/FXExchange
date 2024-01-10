using ExchangeLibrary.Interfaces;
using ExchangeLibrary.Models;

namespace Exchange
{
    internal class RatesProvider : ICurrencyRateProvider
    {
        private List<Currency> countries;
        private List<Rate> exchangeRates;

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

            exchangeRates = new List<Rate>
            {
                new Rate() { BaseCurrency = countries[0], Currency = countries[1], ExchangeRate = 743.94m },
                new Rate() { BaseCurrency = countries[0], Currency = countries[2], ExchangeRate = 663.11m },
                new Rate() { BaseCurrency = countries[0], Currency = countries[3], ExchangeRate = 852.85m },
                new Rate() { BaseCurrency = countries[0], Currency = countries[4], ExchangeRate = 76.10m },
                new Rate() { BaseCurrency = countries[0], Currency = countries[5], ExchangeRate = 78.40m },
                new Rate() { BaseCurrency = countries[0], Currency = countries[6], ExchangeRate = 683.58m },
                new Rate() { BaseCurrency = countries[0], Currency = countries[7], ExchangeRate = 5.9740m }
            };  
        }
        
        public IList<Rate> GetRates()
        {
            
            return exchangeRates;
        }
    }
}
