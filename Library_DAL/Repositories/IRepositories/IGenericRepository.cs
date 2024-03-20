using System.Linq.Expressions;

namespace Libriary_DAL.Repositories.IRepositories
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
