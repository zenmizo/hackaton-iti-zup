package itau.iti.marketplace

import org.springframework.boot.autoconfigure.EnableAutoConfiguration
import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication
import org.springframework.cloud.openfeign.EnableFeignClients
import springfox.documentation.swagger2.annotations.EnableSwagger2

@SpringBootApplication
@EnableAutoConfiguration
@EnableFeignClients
class MarketplaceBffApplication

fun main(args: Array<String>) {
	runApplication<MarketplaceBffApplication>(*args)
}
