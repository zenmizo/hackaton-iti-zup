package itau.iti.marketplace.builder

import br.com.zup.beagle.core.ServerDrivenComponent
import br.com.zup.beagle.widget.core.*
import br.com.zup.beagle.widget.layout.Container
import br.com.zup.beagle.widget.layout.NavigationBar
import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.Text
import itau.iti.marketplace.components.ListProductComponent
import itau.iti.marketplace.service.response.Product

class ListCartBuilder {

    lateinit var products: List<Product>

    fun withProducts(products: List<Product>): ListCartBuilder {
        this.products = products
        return this
    }

    fun buildScreen(): Screen {
        var children = mutableListOf<ServerDrivenComponent>()

        var listProductComponent = ListProductComponent()
        val products =  this.products
        if (products.size > 1) {
            listProductComponent.products = products
            val productsSize = Size(width = UnitValue(100.0, UnitType.PERCENT), height = UnitValue(80.0, UnitType.PERCENT))
            var flexProducts = Flex(size = productsSize, flexDirection = FlexDirection.COLUMN, alignItems = Alignment.CENTER,justifyContent = JustifyContent.CENTER)
            listProductComponent.applyFlex(flexProducts)
            children.add(listProductComponent)
        } else {
            val sizeDescription = Size(width = UnitValue(100.0, UnitType.PERCENT), height = UnitValue(150.0, UnitType.REAL))
            var flexDescription = Flex(size = sizeDescription, flexDirection = FlexDirection.COLUMN, alignItems = Alignment.CENTER,justifyContent = JustifyContent.CENTER)
            var childrenEmpty = mutableListOf<ServerDrivenComponent>()
            childrenEmpty.add(Text("Seu carrinho está vazio"))
            children.add(Container(children = childrenEmpty).applyFlex(flexDescription))
        }

        val Screen = Screen(navigationBar = NavigationBar(title = "Carrinho", showBackButton = true),
                content = Container(children = children))

        return  Screen
    }
}