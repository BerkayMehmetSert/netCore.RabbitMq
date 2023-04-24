using System.Linq.Expressions;
using API.Models.Common;

namespace API.Application.Repositories
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll(Expression<Func<T, bool>>? expression = null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
