package itau.iti.marketplace.controller

import itau.iti.marketplace.service.ProductClientImpl
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.ResponseBody
import org.springframework.web.bind.annotation.RestController


@RestController
class ProductController (private val productServiceImpl: ProductClientImpl) {

    @GetMapping("list/product")
//    fun getProductScreen() = productServiceImpl.getAllProductsScreen();
//    fun createDemo() = Screen(content = Text("Hello, world!"))
    @ResponseBody
    fun getProductList() = productServiceImpl.getAllProducts();
}