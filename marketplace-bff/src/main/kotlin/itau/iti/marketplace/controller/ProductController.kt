package itau.iti.marketplace.controller

import itau.iti.marketplace.exception.ProductIntegrationExceptionHandler
import itau.iti.marketplace.exception.ProductNotFoundException
import itau.iti.marketplace.service.ProductClientImpl
import org.springframework.web.bind.annotation.ExceptionHandler
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.ResponseBody
import org.springframework.web.bind.annotation.RestController


@RestController
class ProductController (private val productServiceImpl: ProductClientImpl) {

    @GetMapping("list/product")
    @ResponseBody
    @ExceptionHandler(ProductNotFoundException::class)
    fun getProductList() = productServiceImpl.getAllProducts();

    @GetMapping("list/product/components")
    @ResponseBody
    fun getProductListComponents(){
        throw ProductNotFoundException()
    };
}