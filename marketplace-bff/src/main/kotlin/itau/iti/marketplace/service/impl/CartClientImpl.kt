package itau.iti.marketplace.service.impl

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.integration.CartIntegration
import itau.iti.marketplace.integration.request.CartPurchase
import itau.iti.marketplace.integration.request.PurchaseProduct
import itau.iti.marketplace.service.CartService

class CartClientImpl: CartService {
    lateinit var cartIntegration: CartIntegration

    override fun addItem(item: PurchaseProduct):Screen {
        cartIntegration.addOnCart("mockIdMobile12319a", item)
    }

    override fun consultCart(customerId: String):Screen {
        cartIntegration.consultCart(customerId)
    }

    override fun removeItem(item: CartPurchase):Screen {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun checkoutCart(cartPurchase: CartPurchase):Screen {
        cartIntegration.checkoutCart(cartPurchase);
    }

}