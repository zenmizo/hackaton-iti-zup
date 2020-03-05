package itau.iti.marketplace.builder

import br.com.zup.beagle.core.ServerDrivenComponent
import br.com.zup.beagle.widget.core.*
import br.com.zup.beagle.widget.layout.Container
import br.com.zup.beagle.widget.layout.NavigationBar
import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.Text
import itau.iti.marketplace.components.ListProductComponent
import itau.iti.marketplace.service.response.Product

class ListProductBuilder {

    private lateinit var products: List<Product>

    fun with(products: List<Product>): ListProductBuilder {
        this.products = products
        return this
    }

    fun buildScreen(): Screen {
        var children = mutableListOf<ServerDrivenComponent>()

        var childrenText = mutableListOf<ServerDrivenComponent>()
        childrenText.add(Text("Lista de Produtos"))
        childrenText.add(Text("Olhá só"))

        val sizeDescription = Size(width = UnitValue(100.0, UnitType.PERCENT), height = UnitValue(150.0, UnitType.REAL))
        var flexDescription = Flex(size = sizeDescription, flexDirection = FlexDirection.COLUMN, alignItems = Alignment.CENTER,justifyContent = JustifyContent.CENTER)
        children.add(Container(children = childrenText).applyFlex(flexDescription))

        var listProductComponent = ListProductComponent()
        val products =  this.products
        if (products.size > 1) {
            listProductComponent.products = products
            val productsSize = Size(width = UnitValue(100.0, UnitType.PERCENT), height = UnitValue(80.0, UnitType.PERCENT))
            var flexProducts = Flex(size = productsSize, flexDirection = FlexDirection.COLUMN, alignItems = Alignment.CENTER,justifyContent = JustifyContent.CENTER)
            listProductComponent.applyFlex(flexProducts)
            children.add(listProductComponent)
        } else {
            var childrenEmpty = mutableListOf<ServerDrivenComponent>()
            childrenEmpty.add(Text("Estamos cadastrando nossos produtos"))
            children.add(Container(children = childrenEmpty).applyFlex(flexDescription))
        }

        var Screen = Screen(navigationBar = NavigationBar(title = "Lista de Produtos", showBackButton = true),
                content = Container(children = children))

        return  Screen

    }
}