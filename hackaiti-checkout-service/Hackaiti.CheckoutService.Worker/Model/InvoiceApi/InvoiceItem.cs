using Newtonsoft.Json;

namespace Hackaiti.CheckoutService.Worker.Model.InvoiceApi
{
    public class InvoiceItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageURL { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("scale")]
        public long Scale { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    }
}