package itau.iti.marketplace.builder

import br.com.zup.beagle.core.Appearance
import br.com.zup.beagle.core.ServerDrivenComponent
import br.com.zup.beagle.widget.core.*
import br.com.zup.beagle.widget.layout.Container
import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.Button
import br.com.zup.beagle.widget.ui.Image
import br.com.zup.beagle.widget.ui.Text

class ResultMessageBuilder {

    lateinit var title: String
    lateinit var description: String
    lateinit var assetImage: String

    fun withTitle(title: String): ResultMessageBuilder {
        this.title = title
        return this
    }
    fun withDescription(description: String): ResultMessageBuilder {
        this.description = description
        return this
    }
    fun withAssetImage(assetImage: String): ResultMessageBuilder {
        this.assetImage = assetImage
        return this
    }

    fun buildScreen(): Screen {
        var childrenContainer = mutableListOf<ServerDrivenComponent>()

        val containerSize = Size(width = UnitValue(100.0, UnitType.PERCENT), height = UnitValue(33.0, UnitType.PERCENT))
        var containerFlex = Flex(justifyContent = JustifyContent.SPACE_AROUND, alignContent = Alignment.CENTER, size = containerSize)

        var chidrenTop = mutableListOf<ServerDrivenComponent>()
        chidrenTop.add(Image("success"))

        childrenContainer.add(Container(chidrenTop).applyFlex(containerFlex))

        var chidrenDescription = mutableListOf<ServerDrivenComponent>()
        chidrenDescription.add(Text(this.title).applyAppearance(Appearance(("FE5886"))))
        chidrenDescription.add(Text(this.description).applyAppearance(Appearance(("000000"))))
        childrenContainer.add(Container(chidrenDescription).applyFlex(containerFlex))

        var chidrenBottom = mutableListOf<ServerDrivenComponent>()
        var buttonSize = Size(width = UnitValue(90.0, UnitType.PERCENT), height = UnitValue(24.0, UnitType.REAL))
        var buttonFlex = Flex(size = buttonSize)
        chidrenBottom.add(Button("voltar a inicio").applyFlex(buttonFlex).applyAppearance(Appearance("F6CA2C")))
        childrenContainer.add(Container(chidrenBottom).applyFlex(containerFlex))
        return Screen(content = Container(childrenContainer))
    }

}