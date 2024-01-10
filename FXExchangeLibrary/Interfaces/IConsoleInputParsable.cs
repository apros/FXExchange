using ExchangeLibrary.Models;

namespace ExchangeLibrary.Interfaces
{
    public interface IInputParsable
    {
        public ExchageArgs ParseInput(string input);
    }
}
