package itau.iti.marketplace.config

import br.com.zup.beagle.serialization.jackson.BeagleActionSerializer
import br.com.zup.beagle.serialization.jackson.BeagleComponentSerializer
import br.com.zup.beagle.serialization.jackson.BeagleScreenSerializer
import com.fasterxml.jackson.databind.ObjectMapper
import com.fasterxml.jackson.databind.module.SimpleModule
import com.fasterxml.jackson.module.kotlin.jacksonObjectMapper
import org.springframework.context.annotation.Bean
import org.springframework.context.annotation.Configuration

@Configuration
class JacksonConfiguration {
    @Bean
    fun objectMapper() : ObjectMapper {
        val mapper = jacksonObjectMapper()
        val module = SimpleModule()
        module.addSerializer(BeagleComponentSerializer())
        module.addSerializer(BeagleActionSerializer())
        module.addSerializer(BeagleScreenSerializer())
        mapper.registerModule(module)
        return mapper
    }
}