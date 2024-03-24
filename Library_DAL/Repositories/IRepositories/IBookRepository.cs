using Libriary_DAL.Entities.Models;

namespace Libriary_DAL.Repositories.IRepositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Book> GetByISBNAsync(int ISBN, CancellationToken cancellationToken = default);
        Task<List<Book>> GetListAsync(CancellationToken cancellationToken = default);
    }
}
