using ExchangeLibrary.Models;

namespace ExchangeLibrary.Interfaces
{
    public interface ICurrencyRateProvider
    {
        public IDictionary<string,Rate> GetRates();
    }
}
