package itau.iti.marketplace.controller

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.service.impl.CartClientImpl
import itau.iti.marketplace.service.request.CartPurchase
import org.springframework.web.bind.annotation.PostMapping
import org.springframework.web.bind.annotation.ResponseBody
import org.springframework.web.bind.annotation.RestController

@RestController
class CartController (private val cartClientImpl: CartClientImpl){

    @PostMapping("add")
    @ResponseBody
    fun addToCart(cartPurchase: CartPurchase): Screen{
        //TODO implement
        return
    }
}