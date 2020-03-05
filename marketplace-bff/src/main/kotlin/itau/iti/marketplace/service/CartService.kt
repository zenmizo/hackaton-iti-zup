package itau.iti.marketplace.service

import itau.iti.marketplace.integration.request.CartPurchase
import itau.iti.marketplace.integration.request.PurchaseProduct

interface CartService {
    fun addItem(item: PurchaseProduct, clientID: String)
    fun consultCart(customerId: String)
    fun removeItem(item: CartPurchase)
    fun checkoutCart(cartPurchase: CartPurchase)
}
