package itau.iti.marketplace.service

import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.Text
import itau.iti.marketplace.service.response.Product
import org.springframework.stereotype.Service

@Service
class ProductServiceImpl : ProductService {
     fun getAllProductsScreen(): Screen {
        return Screen(content = Text("Hello, world!"))

    }

    override fun getAllProducts(): List<Product> {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

}