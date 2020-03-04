package itau.iti.marketplace.service.response

data class Product (
        val sku: Int?,
        val name: String?,
        val shortDescription: String?,
        val value: String?,
        val imageUrl: String?
)