package itau.iti.marketplace.integration.response


data class PurchaseDTO (
    val id: Int,
    val customerId: String,
    val status: PurchaseStatus,
    val items: List<PurchasedProductDTO>

)
