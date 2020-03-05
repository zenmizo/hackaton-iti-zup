package itau.iti.marketplace.service.impl

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.builder.ListCartBuilder
import itau.iti.marketplace.integration.CartIntegration
import itau.iti.marketplace.integration.request.CartPurchase
import itau.iti.marketplace.integration.request.PurchaseProduct
import itau.iti.marketplace.integration.response.PriceDTO
import itau.iti.marketplace.integration.response.ProductDTO
import itau.iti.marketplace.service.CartService
import itau.iti.marketplace.service.response.Product
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Service

@Service
class CartClientImpl(private var cartIntegration: CartIntegration): CartService {

    fun getAllProducts(): List<Product> {
        val product1 = ProductDTO(
                "AAA113",
                "Espresso",
                "Blue Ridge Blend",
                "Blue Ridge Blend Long",
                "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png",
                PriceDTO(
                        20000,
                        2,
                        "EUR"
                )
                ,
                id = "1231"
        )
        val product2 = ProductDTO(
                "AAA113",
                "Chá",
                "Blue Ridge Blend",
                "Blue Ridge Blend Long",
                "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png",
                PriceDTO(
                        20000,
                        2,
                        "EUR"
                )
                ,
                id = "1231"
        )
        val productList = mutableListOf<Product>();
        listOf(product1, product2).forEach {
            p ->
            var product = Product(p)
            product.canBeSelected = false
            productList.add(product)
        }

        return productList;
    }

    override fun addItem(item: PurchaseProduct, clientID: String) {
        cartIntegration.addOnCart(clientID, item)
    }

    override fun consultCart(customerId: String): Screen {
//        cartIntegration.consultCart(customerId)
        return ListCartBuilder().withProducts(getAllProducts()).buildScreen()
    }

    override fun removeItem(item: CartPurchase) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun checkoutCart(cartPurchase: CartPurchase) {
        cartIntegration.checkoutCart(cartPurchase);
    }

}