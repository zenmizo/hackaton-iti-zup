using Backend.Domain.Models.CartModel;

namespace Backend.Domain.Models.InvoiceModel
{
    public class Invoice
    {
        public InvoiceMetadata invoice { get; set; }
        public Cart cart { get; set; }
    }
}
