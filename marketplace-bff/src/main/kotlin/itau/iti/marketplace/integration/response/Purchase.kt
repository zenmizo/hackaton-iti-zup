package itau.iti.marketplace.integration.response


data class Purchase (
    val id: Int,
    val customerId: String,
    val status: PurchaseStatus,
    val items: List<PurchasedProduct>

)
