package itau.iti.marketplace.service

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.integration.request.CartPurchase
import itau.iti.marketplace.integration.request.PurchaseProduct

interface CartService {
    fun addItem(item: PurchaseProduct): Screen
    fun consultCart(customerId: String): Screen
    fun removeItem(item: CartPurchase): Screen
    fun checkoutCart(cartPurchase: CartPurchase): Screen
}
