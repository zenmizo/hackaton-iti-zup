package itau.iti.marketplace.service

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.service.response.Product

interface ProductService {
    fun getAllProducts() : List<Product>
    fun getAllProductsScreen() : Screen
}