using System.Reflection;
using API.Application.RabbitMq;
using API.Application.Services;

namespace API.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IRabbitMqProducer, RabbitMqProducer>();
        }
    }
}
