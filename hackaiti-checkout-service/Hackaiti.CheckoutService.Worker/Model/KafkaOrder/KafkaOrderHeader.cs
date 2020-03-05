using Newtonsoft.Json;

namespace Hackaiti.CheckoutService.Worker.Model.KafkaOrder
{
    public class KafkaOrderHeader
    {
        [JsonProperty("x-team-control")]
        public string XTeamControl { get; set; }
    }
}