package itau.iti.marketplace.integration.response

data class PriceDTO(
        val amount: Int,
        val scale: Int,
        val currencyCode: String
){
    override fun toString(): String {
        val stringBuilder = StringBuilder()

        stringBuilder.append(currencyCode)
        stringBuilder.append(amount)
        stringBuilder.insert(stringBuilder.toString().length-scale,",")
        stringBuilder.insert(currencyCode.length, " ")
        return stringBuilder.toString()
    }
}