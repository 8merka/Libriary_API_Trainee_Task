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
        Task<List<AuthorDTO>> GetAllAuthorsAsync(CancellationToken cancellationToken = default);
        Task<AuthorDTO> CreateAuthorAsync(AuthorDTO authorDTO);
        Task<AuthorDTO> UpdateAuthorAsync(AuthorToUpdateDTO authorToUpdateDTO);
        Task DeleteAuthorAsync(int id);
    }
}
