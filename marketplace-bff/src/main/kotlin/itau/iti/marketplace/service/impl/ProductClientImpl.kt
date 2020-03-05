package itau.iti.marketplace.service.impl

import br.com.zup.beagle.widget.layout.Screen
import itau.iti.marketplace.builder.DeatailProductBuilder
import itau.iti.marketplace.builder.ListProductBuilder
import itau.iti.marketplace.builder.ResultMessageBuilder
import itau.iti.marketplace.integration.ProductIntegration
import itau.iti.marketplace.service.ProductService
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

    fun buyProducts(): Screen {
        return ResultMessageBuilder()
                .withTitle("Order successfully!")
                .withDescription("All right with your order.")
                .withAssetImage("success")
                .buildScreen()
    }

    fun getProduct(sku: String): Screen {
        return DeatailProductBuilder()
                .buildScreen()
    }


}