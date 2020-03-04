package itau.iti.marketplace.integration.response

import itau.iti.marketplace.service.response.Product

data class Purchase (
    val id: Int,
    val customerId: String,
    val status: PurchaseStatus,
    val items: List<PurchasedProduct>

)
