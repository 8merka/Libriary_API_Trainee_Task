using Libriary_BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Services.IService
{
    public interface IIssueService
    {
        //Task<List<IssueDTO>> GetAllIssuesAsync(CancellationToken cancellationToken);
        Task<List<IssueDTO>> GetAllFullBooksAsync(CancellationToken cancellationToken);
        Task<IssueDTO> GetFullBookInfoAsync(int bookId, CancellationToken cancellationToken);
        Task<IssueDTO> GetFullBookInfoByISBNAsync(int ISBN, CancellationToken cancellationToken);
        Task<IssueToCreateDTO> CreateIssueAsync(IssueToCreateDTO issueDTO, CancellationToken cancellationToken = default);
        Task<IssueDTO> UpdateIssueAsync(IssueToUpdateDTO issueToUpdateDTO, CancellationToken cancellationToken = default);
        Task DeleteIssueAsync(int id, CancellationToken cancellationToken = default);
    }
}
