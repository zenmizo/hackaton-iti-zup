package itau.iti.marketplace.service

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.integration.request.CartPurchase
import itau.iti.marketplace.integration.request.PurchaseProduct

interface CartService {
    fun addItem(item: PurchaseProduct, clientID: String)
    fun consultCart(customerId: String): Screen
    fun removeItem(item: CartPurchase)
    fun checkoutCart(cartPurchase: CartPurchase)
}
