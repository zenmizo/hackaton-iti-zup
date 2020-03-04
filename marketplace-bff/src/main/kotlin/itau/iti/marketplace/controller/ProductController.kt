package itau.iti.marketplace.controller

import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.Text
import itau.iti.marketplace.service.ProductServiceImpl
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.RestController

@RestController
class ProductController (private val productServiceImpl: ProductServiceImpl) {

    @GetMapping("list/product")
    fun getProductScreen() = productServiceImpl.getAllProductsScreen();
//    fun createDemo() = Screen(content = Text("Hello, world!"))
    //fun getProductList() = productServiceImpl.getAllProducts();
}