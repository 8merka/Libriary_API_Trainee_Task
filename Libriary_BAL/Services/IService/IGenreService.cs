using Libriary_BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Services.IService
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetAllGenresAsync(CancellationToken cancellationToken = default);
        Task<GenreDTO> CreateGenreAsync(GenreDTO genreDTO, CancellationToken cancellationToken = default);
        Task<GenreDTO> UpdateGenreAsync(GenreToUpdateDTO genreToUpdateDTO, CancellationToken cancellationToken = default);
        Task DeleteGenreAsync(int id, CancellationToken cancellationToken = default);
    }
}
