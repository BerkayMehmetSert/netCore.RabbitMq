using API.Application.Repositories;
using API.Models.Entities;
using API.Persistence.Context;

namespace API.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product, BaseDbContext>, IProductRepository
    {
        public ProductRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<Product> GetById(Guid id)
        {
            return await Get(x => x.Id == id);
        }
    }
}
