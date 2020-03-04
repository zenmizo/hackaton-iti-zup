package itau.iti.marketplace.service

import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.Text
import itau.iti.marketplace.integration.ProductIntegration
import itau.iti.marketplace.integration.response.ProductDTO
import itau.iti.marketplace.service.response.Product
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Service

@Service
class ProductClientImpl : ProductService {
    @Autowired
    lateinit var productIntegration: ProductIntegration;

     override fun getAllProductsScreen(): Screen {
        return Screen(content = Text("Hello, world!"))

    }

    override fun getAllProducts(): List<Product> {
        val product = Product(
                "1",
                "Espresso",
                "Blue Ridge Blend",
                "USD4,35",
                "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"
        )
        val product1 = Product(
                "2",
                "Choco Frappe",
                "Locally Roasted",
                "USD100,0",
                "https://marvel-live.freetls.fastly.net/canvas/2020/2/21ff216dc11440b4b4f6dd7893ba7988?quality=95&fake=.png"
        )


        return listOf(product,product1);
//        return productIntegration.getAllProducts();
    }

    fun getProductsRest(){

    }



}