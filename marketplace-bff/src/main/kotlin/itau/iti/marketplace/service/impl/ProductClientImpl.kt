package itau.iti.marketplace.service.impl

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.builder.DeatailProductBuilder
import itau.iti.marketplace.builder.ListProductBuilder
import itau.iti.marketplace.builder.ResultMessageBuilder
import itau.iti.marketplace.integration.ProductIntegration
import itau.iti.marketplace.integration.response.PriceDTO
import itau.iti.marketplace.integration.response.ProductDTO
import itau.iti.marketplace.service.ProductService
import itau.iti.marketplace.service.request.CartPurchase
import itau.iti.marketplace.service.response.Product
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Service

@Service
class ProductClientImpl : ProductService {
    @Autowired
    lateinit var productIntegration: ProductIntegration;


    override fun getAllProducts(): List<Product> {

        val productList = mutableListOf<Product>();

        productIntegration.getAllProducts().map { productDTO -> productList.add(Product(productDTO)) }
        return productList;
    }

    override fun getAllProductsScreen(): Screen {
       return ListProductBuilder().with(getAllProducts()).buildScreen()
    }

    fun buyProducts(cartPurchase: CartPurchase): Screen {
        return ResultMessageBuilder()
                .withTitle("Order successfully!")
                .withDescription("All right with your order.")
                .withAssetImage("success")
                .buildScreen()
    }

    fun getProduct(sku: String): Screen {
        val product = ProductDTO(
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

        return DeatailProductBuilder()
                .buildScreen()
    }


}