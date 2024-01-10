using ExchangeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeLibrary.Interfaces
{
    public interface ICurrencyRateProvider
    {
        public IList<Rate> GetRates();
    }
}
