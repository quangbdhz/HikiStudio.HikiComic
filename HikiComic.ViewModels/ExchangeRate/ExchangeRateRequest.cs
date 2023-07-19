namespace HikiComic.ViewModels.ExchangeRate
{
    public class ExchangeRateRequest
    {
        public double Amount { get; set; }

        public string CurrencyCode { get; set; }

        public string CurrencyCodeDefault { get; set; } = "VND";
    }
}
