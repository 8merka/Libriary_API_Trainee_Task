using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
using Libriary_BAL.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet]
        [ActionName("GetAllBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBooksAsync(CancellationToken cancellationToken)
        {
            var books = await _bookService.GetAllBooksAsync(cancellationToken);
            return Ok(books.ToList());
        }

        [HttpGet]
        [ActionName("GetBookByISBN")]
        [Route("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookByISBNAsync([FromRoute] int isbn, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookByISBNAsync(isbn, cancellationToken);
            return Ok(book);
        }

        [HttpGet]
        [ActionName("GetBookById")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookByIdAsync(id, cancellationToken);
            return Ok(book);
        }
        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [ActionName("CreateBook")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookToCreateDTO bookDTO)
        {
            await _bookService.CreateBookAsync(bookDTO);
            return Created();
        }
        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [ActionName("UpdateBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBookAsync([FromBody] BookToUpdateDTO bookToUpdateDTO)
        {
            await _bookService.UpdateBookAsync(bookToUpdateDTO);
            return Ok(bookToUpdateDTO);
        }
        [Authorize(Roles = Roles.Admin)]
        [HttpDelete]
        [ActionName("DeleteBook")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Ok();
        }
    }
}
