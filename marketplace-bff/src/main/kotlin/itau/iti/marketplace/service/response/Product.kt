package itau.iti.marketplace.service.response

import itau.iti.marketplace.integration.response.ProductDTO

data class Product(
        val sku: String,
        val name: String,
        val shortDescription: String,
        val value: String,
        val imageUrl: String
)
object ModelMapper {
    fun from(productDTO: ProductDTO) =
            Product(productDTO.sku,
                    productDTO.name,
                    productDTO.shortDescription,
                    "100,00",
                    productDTO.imageUrl)
}