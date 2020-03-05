package itau.iti.marketplace.service.request

data class CartPurchase (
    val customerId: String,
    val item: List<ProductPurchase>
)