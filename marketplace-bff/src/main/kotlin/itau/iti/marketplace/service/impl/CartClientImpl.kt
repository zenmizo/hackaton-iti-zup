package itau.iti.marketplace.service.impl

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.integration.CartIntegration
import itau.iti.marketplace.integration.request.CartPurchase
import itau.iti.marketplace.integration.request.PurchaseProduct
import itau.iti.marketplace.service.CartService
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Service

@Service
class CartClientImpl: CartService {
    lateinit var cartIntegration: CartIntegration

    override fun addItem(item: PurchaseProduct, clientID: String) {
        cartIntegration.addOnCart(clientID, item)
    }

    override fun consultCart(customerId: String) {
        cartIntegration.consultCart(customerId)
    }

    override fun removeItem(item: CartPurchase) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun checkoutCart(cartPurchase: CartPurchase) {
        cartIntegration.checkoutCart(cartPurchase);
    }

}