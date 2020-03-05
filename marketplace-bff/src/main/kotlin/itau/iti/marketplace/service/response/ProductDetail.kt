package itau.iti.marketplace.service.response

import itau.iti.marketplace.integration.response.ProductDTO

data class ProductDetail(
        val sku: String,
        val name: String,
        val shortDescription: String,
        val longDescription: String,
        val value: String,
        val imageUrl: String
){
    constructor(productDTO: ProductDTO): this(productDTO.sku,
        productDTO.name,
        productDTO.shortDescription,
        productDTO.longDescription,
        productDTO.price.toString(),
        productDTO.imageUrl){
    }


}