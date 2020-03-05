package itau.iti.marketplace.builder

import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.Text

class DeatailProductBuilder {

    lateinit var skuProduct: String

    fun buildScreen(): Screen {
        return Screen(content = Text("produto"))
    }


}