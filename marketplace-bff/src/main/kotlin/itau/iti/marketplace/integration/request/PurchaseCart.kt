package itau.iti.marketplace.integration.request

data class PurchaseCart (
    val customerId: String,
    val item: PurchaseProduct
)