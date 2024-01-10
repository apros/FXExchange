namespace ExchangeLibrary.Models
{
    public class Rate
    {
        public Currency BaseCurrency { get; set; }
        public Currency Currency { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
