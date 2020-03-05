package itau.iti.marketplace.service

import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.Text
import itau.iti.marketplace.integration.ProductIntegration
import itau.iti.marketplace.integration.response.PriceDTO
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
//        val product = ProductDTO(
//                "AAA113",
//                "Espresso",
//                "Blue Ridge Blend",
//                "Blue Ridge Blend Long",
//                "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png",
//                PriceDTO(
//                        20000,
//                        2,
//                        "EUR"
//                        )
//        )
//        val product1 = ProductDTO(
//                "BBB1012",
//                "Keyboark",
//                "Keyboard White",
//                "Keyboard Batery White",
//                "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png",
//                PriceDTO(
//                        35999,
//                        2,
//                        "EUR"
//                )
//        )
//
        val productList = mutableListOf<Product>();

//        listOf(product,product1).forEach{p -> productList.add(Product(p))}

        productIntegration.getAllProducts().map { productDTO -> productList.add(Product(productDTO)) }
        return productList;
    }



}