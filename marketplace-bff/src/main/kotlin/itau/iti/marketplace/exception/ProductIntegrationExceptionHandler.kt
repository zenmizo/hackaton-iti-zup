package itau.iti.marketplace.exception

import br.com.zup.beagle.widget.layout.Screen
import br.com.zup.beagle.widget.ui.Text
import org.springframework.http.HttpStatus
import org.springframework.http.ResponseEntity
import org.springframework.web.bind.annotation.ControllerAdvice
import org.springframework.web.bind.annotation.ExceptionHandler
import org.springframework.web.context.request.WebRequest
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler

@ControllerAdvice
class ProductIntegrationExceptionHandler : ResponseEntityExceptionHandler() {
    @ExceptionHandler(value = [(ProductNotFoundException::class)])
    fun handleUserAlreadyExists(ex: ProductNotFoundException,request: WebRequest): ResponseEntity<Screen> {

        return ResponseEntity(Screen(content = Text("ERROR SCREEN")),HttpStatus.ACCEPTED)
    }

}