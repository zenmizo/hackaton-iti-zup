package itau.iti.marketplace.service

import br.com.zup.beagle.core.Appearance
import br.com.zup.beagle.core.ServerDrivenComponent
import br.com.zup.beagle.widget.core.*
import br.com.zup.beagle.widget.layout.Container
import br.com.zup.beagle.widget.layout.NavigationBar
import br.com.zup.beagle.widget.layout.SafeArea
import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.Button
import br.com.zup.beagle.widget.ui.Image
import br.com.zup.beagle.widget.ui.Text
import itau.iti.marketplace.components.ListProductComponent
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

//     override fun getAllProductsScreen(): Screen {
//        return Screen(content = Text("Hello, world!"))
//
//    }

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

        val productList = mutableListOf<Product>();

//        listOf(product,product1).forEach{p -> productList.add(Product(p))}

        productIntegration.getAllProducts().map { productDTO -> productList.add(Product(productDTO)) }
        return productList;
    }

    override fun getAllProductsScreen(): Screen {
        var children = mutableListOf<ServerDrivenComponent>()

        var childrenText = mutableListOf<ServerDrivenComponent>()
        childrenText.add(Text("Lista de Produtos"))
        childrenText.add(Text("Olhá só"))

        val sizeDescription = Size(width = UnitValue(100.0, UnitType.PERCENT), height = UnitValue(150.0, UnitType.REAL))
        var flexDescription = Flex(size = sizeDescription, flexDirection = FlexDirection.COLUMN, alignItems = Alignment.CENTER,justifyContent = JustifyContent.CENTER)
        children.add(Container(children = childrenText).applyFlex(flexDescription))

        var listProductComponent = ListProductComponent()
        val products =  getAllProducts()
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

    fun buyProducts(): Screen {
        var childrenContainer = mutableListOf<ServerDrivenComponent>()

        val containerSize = Size(width = UnitValue(100.0, UnitType.PERCENT), height = UnitValue(33.0, UnitType.PERCENT))
        var containerFlex = Flex(justifyContent = JustifyContent.SPACE_AROUND, alignContent = Alignment.CENTER, size = containerSize)

        var chidrenTop = mutableListOf<ServerDrivenComponent>()
        chidrenTop.add(Image("success"))

        childrenContainer.add(Container(chidrenTop).applyFlex(containerFlex))

        var chidrenDescription = mutableListOf<ServerDrivenComponent>()
        chidrenDescription.add(Text("Order successfully!").applyAppearance(Appearance(("FE5886"))))
        chidrenDescription.add(Text("All right with your order.").applyAppearance(Appearance(("000000"))))
        childrenContainer.add(Container(chidrenDescription).applyFlex(containerFlex))

        var chidrenBottom = mutableListOf<ServerDrivenComponent>()
        var buttonSize = Size(width = UnitValue(90.0, UnitType.PERCENT), height = UnitValue(24.0, UnitType.REAL))
        var buttonFlex = Flex(size = buttonSize)
        chidrenBottom.add(Button("voltar a inicio").applyFlex(buttonFlex).applyAppearance(Appearance("F6CA2C")))
        childrenContainer.add(Container(chidrenBottom).applyFlex(containerFlex))

        return Screen(content = Container(childrenContainer))
    }



}