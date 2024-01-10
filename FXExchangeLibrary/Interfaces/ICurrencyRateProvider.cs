using ExchangeLibrary.Models;

namespace ExchangeLibrary.Interfaces
{
    public interface ICurrencyRateProvider
    {
        public IList<Rate> GetRates();
    }
}
