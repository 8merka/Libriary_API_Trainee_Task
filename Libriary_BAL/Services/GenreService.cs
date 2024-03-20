using AutoMapper;
using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
using Libriary_DAL.Entities.Constants;
using Libriary_BAL.Utilities.Exceptions;
using Libriary_DAL.Entities.Models;
using Libriary_DAL.Repositories.IRepositories;
using Microsoft.Extensions.Logging;

namespace Libriary_BAL.Services
{
    public class GenreService(
        ILogger<GenreService> logger,
        IMapper mapper,
        IGenreRepository genreRepository
        ) : IGenreService
    {
        private readonly ILogger<GenreService> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IGenreRepository _genreRepository = genreRepository;

        public async Task<List<GenreDTO>> GetAllGenresAsync(CancellationToken cancellationToken = default)
        {
            var genresToReturn = await _genreRepository.GetListAsync(cancellationToken: cancellationToken);
            _logger.LogInformation("List of {Count} genres has been returned", genresToReturn.Count);

            return _mapper.Map<List<GenreDTO>>(genresToReturn);
        }

        public async Task<GenreDTO> CreateGenreAsync(GenreDTO genreDTO)
        {
            _logger.LogInformation("Creating new genre {BookGenre}", genreDTO.BookGenre);

            var createdGenre = await _genreRepository.AddAsync(_mapper.Map<Genre>(genreDTO));

            return _mapper.Map<GenreDTO>(createdGenre);
        }

        public async Task<GenreDTO> UpdateGenreAsync(GenreToUpdateDTO genreToUpdateDTO)
        {
            var genre = await _genreRepository.GetAsync(x => x.GenreId == genreToUpdateDTO.GenreId);

            if (genre is null)
            {
                _logger.LogError("Genre with genreId = {GenreId} was not found", genreToUpdateDTO.GenreId);
                throw new NotFoundException(Messages.genreNotFound);
            }

            var genreToUpdate = _mapper.Map<Genre>(genreToUpdateDTO);

            _logger.LogInformation("Genre with these properties: {@genreToUpdate} has been updated", genreToUpdateDTO);
            return _mapper.Map<GenreDTO>(await _genreRepository.UpdateAsync(genreToUpdate));
        }

        public async Task DeleteGenreAsync(int id)
        {
            var genreToDelete = await _genreRepository.GetAsync(x => x.GenreId == id);
            if (genreToDelete is null)
            {
                _logger.LogError("Genre with genreId = {id} was not found", id);
                throw new NotFoundException(Messages.genreNotFound);
            }
            await _genreRepository.DeleteAsync(genreToDelete);
        }
    }
}
