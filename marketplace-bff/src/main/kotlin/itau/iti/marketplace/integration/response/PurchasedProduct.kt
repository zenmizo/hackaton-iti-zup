package itau.iti.marketplace.integration.response

data class PurchasedProduct (
        val id: Int,
        val price: Double,
        val scale: Int,
        val currencyCode: String
)
