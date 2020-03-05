using Backend.Domain.Models.CartModel;

namespace Backend.Domain.Models.InvoiceModel
{
    public class Invoice
    {
        public string xTeamControl { get; set; }
        public string currencyCode { get; set; }
        public Cart cart { get; set; }
    }
}
