package itau.iti.marketplace.controller

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.exception.ProductNotFoundException
import org.springframework.web.bind.annotation.*
import itau.iti.marketplace.service.impl.ProductClientImpl
import itau.iti.marketplace.service.request.ProductPurchase
import itau.iti.marketplace.service.request.CartPurchase
import org.springframework.web.bind.annotation.ExceptionHandler
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.PostMapping
import org.springframework.web.bind.annotation.ResponseBody
import org.springframework.web.bind.annotation.RestController

@RestController
class ProductController (private val productServiceImpl: ProductClientImpl) {

    @GetMapping("list/product")
    @ResponseBody
    fun getProductList(): Screen {
        return productServiceImpl.getAllProductsScreen()
    };

    @GetMapping("product")
    @ResponseBody
    fun getProduct(@RequestParam("sku_product") skuProduct: String): Screen {
        return productServiceImpl.getProduct(sku = skuProduct)
    };

    @GetMapping("list/product/components")
    @ResponseBody
    fun getProductListComponents(){
        throw ProductNotFoundException()
    };

    @PostMapping("buy/products")
    @ResponseBody
    fun buyProducts(cartPurchase: CartPurchase): Screen{
        return productServiceImpl.buyProducts(cartPurchase)
    };
}