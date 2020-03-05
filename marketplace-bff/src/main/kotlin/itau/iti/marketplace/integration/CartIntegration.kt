package itau.iti.marketplace.integration

import itau.iti.marketplace.integration.response.PurchaseDTO
import org.springframework.cloud.openfeign.FeignClient
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.RequestMethod

@FeignClient("cart", url = "192.168.0.131:7000")
interface CartIntegration {
    @RequestMapping(method = [RequestMethod.POST], value = ["/carts"])
    fun purchaseCart(): PurchaseDTO;
}