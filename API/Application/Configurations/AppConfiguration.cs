namespace API.Application.Configurations
{
    public class AppConfiguration
    {
        public string RabbitMQHost { get; set; }
        public string RabbitMQUsername { get; set; }
        public string RabbitMQPassword { get; set; }

        public string RabbitMQExchance { get; set; }
        public string RabbitMQQueue { get; set; }
        public string RabbitMQRoutingKey { get; set; }
    }
}
