using API.Models.Entities;

namespace API.Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetById(Guid id);
    }
}
