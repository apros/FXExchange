using ExchangeLibrary.Interfaces;
using ExchangeLibrary.Models;
using System.Globalization;

namespace ExchangeLibrary
{
    public class ConsoleInputParser : IInputParsable
    {

        private readonly CultureInfo culture;

        public ConsoleInputParser()
        {
            this.culture = CultureInfo.GetCultureInfo("da-DK");
        }

        public ConsoleInputParser(CultureInfo culture)
        {
            this.culture = culture ?? throw new ArgumentNullException(nameof(culture));
        }

        public ExchageArgs ParseInput(string input)
        {            

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input cannot be null or empty.");
            }

            var args = input.Split(' ');
            if (args.Length != 2)
            {
                throw new ArgumentException("Invalid input format.");
            }

            var currencies = args[0].Split('/');
            if (currencies.Length != 2)
            {
                throw new ArgumentException("Invalid currency pair format.");
            }

            string moneyCurrency = currencies[0];
            string baseCurrency = currencies[1];
            

            if (decimal.TryParse(args[1], NumberStyles.Number, culture, out decimal amount))
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Amount must be greater than 0.");
                }

                return new ExchageArgs( moneyCurrency,baseCurrency, amount);
            }
            else
            {
                throw new ArgumentException("Invalid amount format.");
            }             

        }
    }
}
