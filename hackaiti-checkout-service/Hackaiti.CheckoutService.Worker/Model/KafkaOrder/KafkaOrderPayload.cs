using Newtonsoft.Json;

namespace Hackaiti.CheckoutService.Worker.Model.KafkaOrder
{
    public class KafkaOrderPayload
    {
        [JsonProperty("cartId")]
        public string CartId { get; set; }

        [JsonProperty("price")]
        public KafkaOrderPayloadPrice Price { get; set; }
    }
}