package itau.iti.marketplace.service

import itau.iti.marketplace.service.response.Product

interface ProductService {
    fun getAllProducts() :List<Product>
}