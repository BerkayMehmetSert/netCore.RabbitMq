using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace API.Application.RabbitMq
{
        public class RabbitMqProducer : IRabbitMqProducer
        {
            public void Publish<T>(T message) where T : class
            {

                var factory = new ConnectionFactory
                {
                    HostName = "localhost"
                };

                var connection = factory.CreateConnection();

                using
                    var channel = connection.CreateModel();
                channel.QueueDeclare("product", exclusive: false);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "", routingKey: "product", body: body);
            }
        }
}
