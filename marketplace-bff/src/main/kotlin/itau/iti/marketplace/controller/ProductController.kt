package itau.iti.marketplace.controller

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.exception.ProductNotFoundException
import itau.iti.marketplace.service.ProductClientImpl
import org.springframework.web.bind.annotation.*


@RestController
class ProductController (private val productServiceImpl: ProductClientImpl) {

    @GetMapping("list/product")
    @ResponseBody
    @ExceptionHandler(ProductNotFoundException::class)
    fun getProductList(): Screen {
        return productServiceImpl.getAllProductsScreen()
//        return productServiceImpl.getProduct(sku = "21312")
    };

    @GetMapping("product")
    @ResponseBody
    @ExceptionHandler(ProductNotFoundException::class)
    fun getProduct(@RequestParam("sku_product") skuProduct: String): Screen {
        return productServiceImpl.getProduct(sku = skuProduct)
    };

    @GetMapping("list/product/components")
    @ResponseBody
    fun getProductListComponents(){
        throw ProductNotFoundException()
    };

    @GetMapping("buy/products")
    @ResponseBody
    fun buyProducts(): Screen {
        return productServiceImpl.buyProducts()
    };
}