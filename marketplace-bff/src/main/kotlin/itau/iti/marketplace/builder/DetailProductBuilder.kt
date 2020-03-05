package itau.iti.marketplace.builder

import br.com.zup.beagle.core.ServerDrivenComponent
import br.com.zup.beagle.widget.core.*
import br.com.zup.beagle.widget.form.Form
import br.com.zup.beagle.widget.form.FormMethodType
import br.com.zup.beagle.widget.layout.Container
import br.com.zup.beagle.widget.layout.NavigationBar
import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.NetworkImage
import br.com.zup.beagle.widget.ui.Text
import itau.iti.marketplace.components.ListProductComponent
import itau.iti.marketplace.service.response.Product
import itau.iti.marketplace.service.response.ProductDetail

class DeatailProductBuilder {

    var product: ProductDetail? = null

    fun withProduct(product: ProductDetail): DeatailProductBuilder {
        this.product = product
        return this
    }

    fun buildScreen(): Screen {
        var childrenProduct = mutableListOf<ServerDrivenComponent>()

        var childrenImage = mutableListOf<ServerDrivenComponent>()
//        childrenImage.add(NetworkImage(path = this.product.imageUrl))
        childrenImage.add(NetworkImage(path = "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))

        val sizeImage = Size(width = UnitValue(100.0, UnitType.PERCENT), height = UnitValue(250.0, UnitType.REAL))
        var flexImage = Flex(size = sizeImage, flexDirection = FlexDirection.COLUMN, alignItems = Alignment.CENTER,justifyContent = JustifyContent.CENTER)

        val imageContaier = Container(childrenImage).applyFlex(flexImage)
        childrenProduct.add(imageContaier)

        var childrenInfo = mutableListOf<ServerDrivenComponent>()
        childrenInfo.add(Text("Café"))
        childrenInfo.add(Text("R$ 12.00"))

        var flexDetail = Flex(
                flexDirection = FlexDirection.ROW,
                alignItems = Alignment.SPACE_BETWEEN,
                justifyContent = JustifyContent.SPACE_BETWEEN)

        val infoContainer = Container(childrenInfo).applyFlex(flexDetail)
        childrenProduct.add(infoContainer)

        var childrenDescription = mutableListOf<ServerDrivenComponent>()
        childrenDescription.add(Text("A deliciously creamy Coffee Kick Frappé, topped with irresistible whipped cream and indulgent Coffee Drizzle. Perfect combination.\n"))
        var flexInfo = Flex(flexWrap = FlexWrap.WRAP,
                flexDirection = FlexDirection.ROW,
                alignContent = Alignment.CENTER,
                alignItems = Alignment.CENTER,
                justifyContent = JustifyContent.CENTER)
        val descriptionContainer = Container(childrenDescription).applyFlex(flexInfo)
        childrenProduct.add(descriptionContainer)

        return  Screen(
                navigationBar = NavigationBar(title = "Detalhe Produto", showBackButton = true)
                ,content = Form(path = "add/$sku",
                method = FormMethodType.POST,
                child = Container(childrenProduct)))
    }


}