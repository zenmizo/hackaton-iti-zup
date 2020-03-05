using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hackaiti.CheckoutService.Worker.Model.InvoiceApi
{
    public class Invoice
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("total")]
        public InvoiceTotal Total { get; set; }

        [JsonProperty("items")]
        public IEnumerable<InvoiceItem> Items { get; set; }
    }
}