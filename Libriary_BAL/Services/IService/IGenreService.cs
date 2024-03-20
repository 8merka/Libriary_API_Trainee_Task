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
        Task<GenreDTO> CreateGenreAsync(GenreDTO genreDTO);
        Task<GenreDTO> UpdateGenreAsync(GenreToUpdateDTO genreToUpdateDTO);
        Task DeleteGenreAsync(int id);
    }
}
