package itau.iti.marketplace.integration

import itau.iti.marketplace.integration.response.Purchase
import org.springframework.cloud.openfeign.FeignClient
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.RequestMethod

@FeignClient("cart")
interface CartIntegration {
    @RequestMapping(method = [RequestMethod.POST], value = ["/carts"])
    fun purchaseCart(): Purchase;
}