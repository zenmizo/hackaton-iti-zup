package itau.iti.marketplace.controller

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.integration.request.PurchaseProduct
import itau.iti.marketplace.service.impl.CartClientImpl
import itau.iti.marketplace.service.request.CartPurchase
import org.springframework.web.bind.annotation.*

@RestController
class CartController (private val cartClientImpl: CartClientImpl){

    @PostMapping("add")
    @ResponseBody
    fun addToCart(@RequestParam(value = "sku") sku: String, @RequestParam(value = "clientID") clientID: String) {
        cartClientImpl.addItem(PurchaseProduct(sku = sku, quantity = 1 ), clientID)
        return
    }

}