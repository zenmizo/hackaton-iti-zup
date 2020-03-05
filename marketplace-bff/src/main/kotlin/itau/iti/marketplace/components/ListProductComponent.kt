package itau.iti.marketplace.components

import br.com.zup.beagle.annotation.RegisterWidget
import br.com.zup.beagle.widget.Widget
import itau.iti.marketplace.service.response.Product

@RegisterWidget
class ListProductComponent: Widget() {

    lateinit var products: List<Product>

}