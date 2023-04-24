using API.Application.Repositories;
using API.Persistence.Context;
using API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "RabbitMqDb"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
