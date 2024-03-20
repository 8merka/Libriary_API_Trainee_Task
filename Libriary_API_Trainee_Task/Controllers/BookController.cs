using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace Libriary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet]
        [Route("GetAllBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBooksAsync(CancellationToken cancellationToken)
        {
            var books = await _bookService.GetAllBooksAsync(cancellationToken);
            return Ok(books.ToList());
        }

        [HttpGet]
        [Route("GetBookByISBN")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookByISBNAsync(int ISBN, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookByISBNAsync(ISBN, cancellationToken);
            return Ok(book);
        }

        [HttpGet]
        [Route("GetBookById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookByIdAsync(int id, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookByIdAsync(id, cancellationToken);
            return Ok(book);
        }

        [HttpPost]
        [Route("CreateBook")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookDTO bookDTO)
        {
            await _bookService.CreateBookAsync(bookDTO);
            return Created();
        }

        [HttpPut]
        [Route("UpdateBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBookAsync([FromBody] BookToUpdateDTO bookToUpdateDTO)
        {
            await _bookService.UpdateBookAsync(bookToUpdateDTO);
            return Ok(bookToUpdateDTO);
        }

        [HttpDelete]
        [Route("DeleteBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Ok();
        }
    }
}
