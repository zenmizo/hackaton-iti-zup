using Newtonsoft.Json;

namespace Hackaiti.CheckoutService.Worker.Model.InvoiceApi
{
    public class InvoiceTotal
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("scale")]
        public long Scale { get; set; }   

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    }
}