namespace API.Application.RabbitMq
{
    public interface IRabbitMqProducer
    {
        void Publish<T>(T message) where T : class;
    }
}
