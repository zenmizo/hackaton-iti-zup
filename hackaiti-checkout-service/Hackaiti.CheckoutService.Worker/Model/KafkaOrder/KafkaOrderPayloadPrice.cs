using Newtonsoft.Json;

namespace Hackaiti.CheckoutService.Worker.Model.KafkaOrder
{
    public class KafkaOrderPayloadPrice
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("scale")]
        public long Scale { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    }
}