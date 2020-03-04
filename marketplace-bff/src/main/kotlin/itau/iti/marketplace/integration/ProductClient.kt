package itau.iti.marketplace.integration

import itau.iti.marketplace.integration.response.ProductDTO
import org.springframework.cloud.openfeign.FeignClient
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.RequestMethod


@FeignClient(name="products")
interface ProductClient {
    @RequestMapping(method = arrayOf(RequestMethod.GET), value = ["product"])
    fun getAllProducts() : List<ProductDTO>
}