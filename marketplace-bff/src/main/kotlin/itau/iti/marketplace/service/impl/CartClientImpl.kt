package itau.iti.marketplace.service.impl

import itau.iti.marketplace.integration.CartIntegration
import itau.iti.marketplace.integration.request.CartPurchase
import itau.iti.marketplace.integration.request.PurchaseProduct
import itau.iti.marketplace.service.CartService

class CartClientImpl: CartService {
    lateinit var cartIntegration: CartIntegration

    override fun addItem(item: PurchaseProduct) {
        cartIntegration.addOnCart("mockIdMobile12319a", item)
    }

    override fun consultCart(customerId: String) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun removeItem(item: CartPurchase) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun checkoutCart(cartPurchase: CartPurchase) {
        cartIntegration.checkoutCart(cartPurchase);
    }

}