namespace MovieStoreApi.MessageProducer.Options
{
    public class RabbitMqProducerConfiguration
    {
        public string Hostname { get; set; }
        public string QueueName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
