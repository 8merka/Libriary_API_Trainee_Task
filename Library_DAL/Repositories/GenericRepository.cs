using Libriary_DAL.Data;
using Libriary_DAL.Repositories.IRepositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Libriary_DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
        }
        public async Task<List<TEntity>> GetListAsync(int pageNumber = 1, int pageSize = 10, Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            var entities = filter == null ? _context.Set<TEntity>() : _context.Set<TEntity>().Where(filter);
            return await entities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _ = _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
        public async Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _ = _context.Remove(entity);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
