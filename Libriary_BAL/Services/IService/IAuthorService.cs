using Libriary_BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Services.IService
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAllAuthorsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<AuthorDTO> CreateAuthorAsync(AuthorDTO authorDTO, CancellationToken cancellationToken = default);
        Task<AuthorDTO> UpdateAuthorAsync(AuthorToUpdateDTO authorToUpdateDTO, CancellationToken cancellationToken = default);
        Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default);
    }
}
