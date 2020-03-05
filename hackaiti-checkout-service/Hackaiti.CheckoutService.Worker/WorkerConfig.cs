namespace Hackaiti.CheckoutService.Worker
{
    // Static class for configs... Really?
    public static class WorkerConfig
    {
        public static string CurrenciesServiceBaseAddress { get; set; } = "http://localhost:8000";

        public static string HackatonZupBaseAddress { get; set; } = "http://localhost:9000";
        // public static string HackatonZupBaseAddress { get; set; } = "http://zup-hackathon-financial.zup.com.br";

        public static string StartCheckoutQueueURL { get; set; } = "https://sqs.us-east-1.amazonaws.com/105029661252/start-checkout";

        public static string DynamoTransactionRegisterTableName { get; set; } = "checkout_transactions";

        public static string KafkaBootstrapServers { get; set; } = "localhost:9092";
        // public static string KafkaBootstrapServers { get; set; } = "18.210.232.248:9092,52.202.175.72:9092,18.204.118.23:9092";
    }
}