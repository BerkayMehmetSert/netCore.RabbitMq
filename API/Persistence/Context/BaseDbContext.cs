using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
