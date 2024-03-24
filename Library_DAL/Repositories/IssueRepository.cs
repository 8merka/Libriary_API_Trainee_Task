using Libriary_DAL.Data;
using Libriary_DAL.Entities.Models;
using Libriary_DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_DAL.Repositories
{
    public class IssueRepository: GenericRepository<Issue>, IIssueRepository
    {
        private readonly AppDbContext _appDbContext;
        public IssueRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Issue>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Set<Issue>()
                .AsNoTracking()
                .Include(b => b.Book)
                .ThenInclude(b => b.Genre)
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .ToListAsync(cancellationToken);
        }
        public async Task<Issue> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Set<Issue>()
                .AsNoTracking()
                .Include(b => b.Book)
                .ThenInclude(b => b.Genre)
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .FirstOrDefaultAsync(i => i.BookId == id, cancellationToken);
        }
        public async Task<Issue> GetByISBNAsync(int ISBN, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Set<Issue>()
                .AsNoTracking()
               .Include(b => b.Book)
                .ThenInclude(b => b.Genre)
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .FirstOrDefaultAsync(e => e.Book.ISBN == ISBN, cancellationToken);
        }


    }
}
