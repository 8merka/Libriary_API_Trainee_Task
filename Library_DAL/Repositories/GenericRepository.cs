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
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await (filter == null ? _context.Set<TEntity>().ToListAsync(cancellationToken) : _context.Set<TEntity>().Where(filter).ToListAsync(cancellationToken));
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _ = _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<int> DeleteAsync(TEntity entity)
        {
            _ = _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
