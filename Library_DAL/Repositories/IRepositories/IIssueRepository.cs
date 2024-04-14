using Libriary_DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_DAL.Repositories.IRepositories
{
    public interface IIssueRepository: IGenericRepository<Issue>
    {
        Task<Issue> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Issue> GetByISBNAsync(int ISBN, CancellationToken cancellationToken = default);
        Task<List<Issue>> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
    }
}
