package itau.iti.marketplace.integration.response

data class PurchasedProductDTO (
        val id: Int,
        val price: Double,
        val scale: Int,
        val currencyCode: String
)
