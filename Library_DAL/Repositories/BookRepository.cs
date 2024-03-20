using Libriary_DAL.Data;
using Libriary_DAL.Entities.Models;
using Libriary_DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Libriary_DAL.Repositories
{
    public class BookRepository: GenericRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _appDbContext;
        public BookRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Set<Book>().AsNoTracking().FirstOrDefaultAsync(e => e.BookId == id, cancellationToken);
        }

        public async Task<Book> GetByISBNAsync(int ISBN, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Set<Book>().AsNoTracking().FirstOrDefaultAsync(e => e.ISBN == ISBN, cancellationToken);
        }

    }
}
