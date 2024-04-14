using AutoMapper;
using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
using Libriary_BAL.Utilities.Exceptions;
using Libriary_DAL.Entities.Models;
using Libriary_DAL.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using Libriary_BAL.Utilities.Constants;

namespace Libriary_BAL.Services
{
    public class AuthorService(
        ILogger<AuthorService> logger,
        IMapper mapper,
        IAuthorRepository authorRepository
        ) : IAuthorService
    {
        private readonly ILogger<AuthorService> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public async Task<List<AuthorDTO>> GetAllAuthorsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var authorsToReturn = await _authorRepository.GetListAsync(pageNumber, pageSize, cancellationToken: cancellationToken);
            _logger.LogInformation("Page {PageNumber} of authors has been returned", pageNumber);
            return _mapper.Map<List<AuthorDTO>>(authorsToReturn);
        }


        public async Task<AuthorDTO> CreateAuthorAsync(AuthorDTO authorDTO, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Creating new author {Name} {LastName}", authorDTO.Name, authorDTO.LastName);

            var createdAuthor = await _authorRepository.AddAsync(_mapper.Map<Author>(authorDTO), cancellationToken: cancellationToken);

            return _mapper.Map<AuthorDTO>(createdAuthor);
        }

        public async Task<AuthorDTO> UpdateAuthorAsync(AuthorToUpdateDTO authorToUpdateDTO, CancellationToken cancellationToken = default)
        {
            var author = await _authorRepository.GetAsync(x => x.AuthorId == authorToUpdateDTO.AuthorId, cancellationToken: cancellationToken);

            if (author is null)
            {
                _logger.LogError("Author with authorId = {AuthorId} was not found", authorToUpdateDTO.AuthorId);
                throw new NotFoundException(Messages.authorNotFound);
            }

            var authorToUpdate = _mapper.Map<Author>(authorToUpdateDTO);

            _logger.LogInformation("Author with these properties: {@authorToUpdate} has been updated", authorToUpdateDTO);
            return _mapper.Map<AuthorDTO>(await _authorRepository.UpdateAsync(authorToUpdate, cancellationToken: cancellationToken));
        }

        public async Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default)
        {
            var authorToDelete = await _authorRepository.GetAsync(x => x.AuthorId == id, cancellationToken: cancellationToken);
            if (authorToDelete is null)
            {
                _logger.LogError("Author with authorId = {id} was not found", id);
                throw new NotFoundException(Messages.authorNotFound);
            }
            await _authorRepository.DeleteAsync(authorToDelete, cancellationToken: cancellationToken);
        }
    }
}