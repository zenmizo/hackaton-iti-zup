package itau.iti.marketplace.integration.response

data class ProductDTO (
    val sku: String,
    val name: String,
    val shortDescription: String,
    val longDescription: String,
    val imageUrl: String,
    val price: PriceDTO,
    var id: String
)
