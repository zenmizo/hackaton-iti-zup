package itau.iti.marketplace.integration

import feign.Param
import itau.iti.marketplace.integration.request.CartPurchase
import itau.iti.marketplace.integration.request.PurchaseProduct
import itau.iti.marketplace.integration.response.PurchaseDTO
import org.springframework.cloud.openfeign.FeignClient
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.RequestMethod

@FeignClient("cart", url = "192.168.0.123:8080")

interface CartIntegration {
    @RequestMapping(method = [RequestMethod.POST], value = ["/carts"])
    fun checkoutCart(cartPurchase: CartPurchase): PurchaseDTO;

    @RequestMapping(method = [RequestMethod.PATCH], value = ["/carts/{id}/items"])
    fun addOnCart(@Param("id") customerId: String, product: PurchaseProduct);

    @RequestMapping(method = [RequestMethod.GET], value = ["/carts/{id}"])
    fun consultCart(@Param("id")id: String): PurchaseDTO;
}