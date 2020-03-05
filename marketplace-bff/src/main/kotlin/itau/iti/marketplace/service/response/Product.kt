package itau.iti.marketplace.service.response

import itau.iti.marketplace.integration.response.ProductDTO

data class Product(
        val sku: String,
        val name: String,
        val shortDescription: String,
        val value: String,
        val imageUrl: String,
        var canBeSelected: Boolean = true
){
    constructor(productDTO: ProductDTO): this(productDTO.sku,
            productDTO.name,
            productDTO.shortDescription,
            productDTO.price.toString(),
            productDTO.imageUrl){
    }

}