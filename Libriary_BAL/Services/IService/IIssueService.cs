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
        Task<List<IssueDTO>> GetAllIssuesAsync(CancellationToken cancellationToken);
        Task<IssueDTO> GetFullBookInfo(int bookId, CancellationToken cancellationToken);
        Task<IssueDTO> CreateIssueAsync(IssueDTO issueDTO);
        Task<IssueDTO> UpdateIssueAsync(IssueToUpdateDTO issueToUpdateDTO);
        Task DeleteIssueAsync(int id);
    }
}
