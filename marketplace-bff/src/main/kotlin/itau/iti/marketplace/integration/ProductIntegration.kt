package itau.iti.marketplace.integration

import itau.iti.marketplace.integration.response.ProductDTO
import org.springframework.cloud.openfeign.FeignClient
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.RequestMethod


@FeignClient(name="products", url = "http://192.168.0.117:5000")
interface ProductIntegration {
    @RequestMapping(method = arrayOf(RequestMethod.GET), value = ["/products"])
    fun getAllProducts() : List<ProductDTO>
    @RequestMapping(method = arrayOf(RequestMethod.GET), value = ["/product/{sku}"])
    fun getProductBySku(sku: String) : ProductDTO
}