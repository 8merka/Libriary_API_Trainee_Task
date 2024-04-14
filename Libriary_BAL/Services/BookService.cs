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
    public class BookService(
        ILogger<BookService> logger,
        IMapper mapper,
        IBookRepository bookRepository
        ) : IBookService
    {
        private readonly ILogger<BookService> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<List<BookDTO>> GetAllBooksAsync(CancellationToken cancellationToken = default)
        {
            var booksToReturn = await _bookRepository.GetListAsync(cancellationToken: cancellationToken);
            _logger.LogInformation("List of {Count} books has been returned", booksToReturn.Count);

            return _mapper.Map<List<BookDTO>>(booksToReturn);
        }
        public async Task<BookDTO> GetBookByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            var bookToReturn = await _bookRepository.GetByIdAsync(Id, cancellationToken: cancellationToken);
            if (bookToReturn is null)
            {
                _logger.LogError("Book with bookId = {BookId} was not found", bookToReturn.BookId);
                throw new NotFoundException(Messages.bookNotFound);
            }
            return _mapper.Map<BookDTO>(bookToReturn);
        }
        public async Task<BookDTO> GetBookByISBNAsync(int ISBN, CancellationToken cancellationToken = default)
        {
            var bookToReturn = await _bookRepository.GetByISBNAsync(ISBN, cancellationToken: cancellationToken);
            if (bookToReturn is null)
            {
                _logger.LogError("Book with ISBN = {ISBN} was not found", bookToReturn.ISBN);
                throw new NotFoundException(Messages.bookNotFound);
            }
            return _mapper.Map<BookDTO>(bookToReturn);
        }

        public async Task<BookToCreateDTO> CreateBookAsync(BookToCreateDTO bookToCreateDTO, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Creating new book {@bookDTO}", bookToCreateDTO);

            var createdBook = await _bookRepository.AddAsync(_mapper.Map<Book>(bookToCreateDTO), cancellationToken: cancellationToken);

            return _mapper.Map<BookToCreateDTO>(createdBook);
        }

        public async Task<BookDTO> UpdateBookAsync(BookToUpdateDTO bookToUpdateDTO, CancellationToken cancellationToken = default)
        {
            var book = await _bookRepository.GetAsync(x => x.BookId == bookToUpdateDTO.BookId, cancellationToken: cancellationToken);

            if (book is null)
            {
                _logger.LogError("Book with bookId = {BookId} was not found", bookToUpdateDTO.BookId);
                throw new NotFoundException(Messages.bookNotFound);
            }

            var bookToUpdate = _mapper.Map<Book>(bookToUpdateDTO);

            _logger.LogInformation("Book with these properties: {@bookToUpdate} has been updated", bookToUpdateDTO);
            return _mapper.Map<BookDTO>(await _bookRepository.UpdateAsync(bookToUpdate, cancellationToken: cancellationToken));
        }

        public async Task DeleteBookAsync(int id, CancellationToken cancellationToken = default)
        {
            var bookToDelete = await _bookRepository.GetAsync(x => x.BookId == id, cancellationToken: cancellationToken);
            if (bookToDelete is null)
            {
                _logger.LogError("Book with bookId = {id} was not found", id);
                throw new NotFoundException(Messages.bookNotFound);
            }
            await _bookRepository.DeleteAsync(bookToDelete, cancellationToken: cancellationToken);
        }
    }
}
