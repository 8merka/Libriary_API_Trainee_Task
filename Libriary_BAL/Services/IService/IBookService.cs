using Libriary_BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Services.IService
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooksAsync(CancellationToken cancellationToken = default);
        Task<BookDTO> GetBookByIdAsync(int bookId,  CancellationToken cancellationToken = default);
        Task<BookDTO> GetBookByISBNAsync(int isbnId, CancellationToken cancellationToken = default);
        Task<BookToCreateDTO> CreateBookAsync(BookToCreateDTO bookDTO);
        Task<BookDTO> UpdateBookAsync(BookToUpdateDTO bookToUpdateDTO);
        Task DeleteBookAsync(int id);
    }
}
