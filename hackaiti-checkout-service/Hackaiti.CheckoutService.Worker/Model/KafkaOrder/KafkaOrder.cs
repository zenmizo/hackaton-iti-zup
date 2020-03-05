using Newtonsoft.Json;

namespace Hackaiti.CheckoutService.Worker.Model.KafkaOrder
{
    public class KafkaOrder
    {
        [JsonProperty("headers")]
        public KafkaOrderHeader Headers { get; set; }

        [JsonProperty("payload")]
        public KafkaOrderPayload Payload { get; set; }
    }
}