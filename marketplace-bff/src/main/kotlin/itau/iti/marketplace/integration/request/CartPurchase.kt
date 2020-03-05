package itau.iti.marketplace.integration.request

import itau.iti.marketplace.service.request.ProductPurchase

data class CartPurchase (
    val customerId: String,
    val item: List<ProductPurchase>
)