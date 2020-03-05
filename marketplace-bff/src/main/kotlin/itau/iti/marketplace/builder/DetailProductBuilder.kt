package itau.iti.marketplace.builder

import br.com.zup.beagle.core.Appearance
import br.com.zup.beagle.core.ServerDrivenComponent
import br.com.zup.beagle.widget.core.*
import br.com.zup.beagle.widget.form.Form
import br.com.zup.beagle.widget.form.FormMethodType
import br.com.zup.beagle.widget.form.FormSubmit
import br.com.zup.beagle.widget.layout.Container
import br.com.zup.beagle.widget.layout.NavigationBar
import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.Button
import br.com.zup.beagle.widget.ui.Image
import br.com.zup.beagle.widget.ui.NetworkImage
import br.com.zup.beagle.widget.ui.Text
import itau.iti.marketplace.components.ListProductComponent
import itau.iti.marketplace.service.response.Product
import itau.iti.marketplace.service.response.ProductDetail

class DeatailProductBuilder {

    lateinit var product: ProductDetail
    lateinit var clientID: String
    fun withProduct(product: ProductDetail): DeatailProductBuilder {
        this.product = product
        return this
    }

    fun withClientID(clientID: String): DeatailProductBuilder {
        this.clientID = clientID
        return this
    }

    fun buildScreen(): Screen {
        var childrenProduct = mutableListOf<ServerDrivenComponent>()
        childrenProduct.add(getBodyContainer())
        childrenProduct.add(getSubmitContainer())

        return  Screen(
                navigationBar = NavigationBar(title =  product.name, showBackButton = true)
                ,content =
        Form(path = "http://localhost:8080/add?sku=${product.sku}&clientID=$clientID",
                method = FormMethodType.POST,
                child = Container(childrenProduct).applyFlex(Flex(justifyContent = JustifyContent.SPACE_BETWEEN, grow = 1.0)))
        )

    }

    fun getBodyContainer(): Container {
        var childrenProduct = mutableListOf<ServerDrivenComponent>()
        childrenProduct.add(getImageContainer())
        childrenProduct.add(getInfoContainer())
        childrenProduct.add(getDescriptionContainer())
        return Container(childrenProduct)
    }

    fun getImageContainer(): Container {
        var childrenImage = mutableListOf<ServerDrivenComponent>()
//        childrenImage.add(NetworkImage(path = this.product.imageUrl))
        childrenImage.add(Image(name = "empty"))

        val sizeImage = Size(width = UnitValue(100.0, UnitType.PERCENT), height = UnitValue(250.0, UnitType.REAL))
        var flexImage = Flex(size = sizeImage, flexDirection = FlexDirection.COLUMN, alignItems = Alignment.CENTER,justifyContent = JustifyContent.CENTER)
        val containerImage = Container(childrenImage)
        containerImage.applyFlex(flexImage)
        return containerImage
    }

    fun getInfoContainer(): Container {
        var childrenInfo = mutableListOf<ServerDrivenComponent>()
        childrenInfo.add(Text(product.name))
        childrenInfo.add(Text(product.value))

        var flexDetail = Flex(
                flexDirection = FlexDirection.ROW,
                alignItems = Alignment.SPACE_BETWEEN,
                justifyContent = JustifyContent.SPACE_BETWEEN)

        val infoContainer = Container(childrenInfo)
        infoContainer.applyFlex(flexDetail)
        return  infoContainer
    }

    fun getDescriptionContainer(): Container {
        var childrenDescription = mutableListOf<ServerDrivenComponent>()
        childrenDescription.add(Text(product.longDescription))
        var flexInfo = Flex(flexWrap = FlexWrap.WRAP,
                flexDirection = FlexDirection.ROW,
                alignContent = Alignment.CENTER,
                alignItems = Alignment.CENTER,
                justifyContent = JustifyContent.CENTER)
        val descriptionContainer = Container(childrenDescription)
        descriptionContainer.applyFlex(flexInfo)
        return  descriptionContainer
    }

    fun getSubmitContainer(): Container {
        var childrenButton = mutableListOf<ServerDrivenComponent>()
        val submitButton = Button(text = "Adicionar ao carrinho")
        val sizeButton = Size(width = UnitValue(90.0, UnitType.PERCENT), height = UnitValue(24.0, UnitType.REAL))
        var flexButton = Flex(size = sizeButton, flexDirection = FlexDirection.COLUMN, alignItems = Alignment.CENTER,justifyContent = JustifyContent.CENTER)
        val containerButton = Container(listOf(FormSubmit(submitButton)))
        containerButton.applyAppearance(Appearance(backgroundColor = "#fa5d6a"))
        return  containerButton
    }




}