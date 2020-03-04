package itau.iti.marketplace.service.response

data class Product (
    val sku: String,
    val name: String,
    val shortDescription: String,
    val longDescription: String,
    val imageUrl: String,
    val price: Price

)

data class Price(
        val amount: Double,
        val scale: Int,
        val currencyCode: String
)