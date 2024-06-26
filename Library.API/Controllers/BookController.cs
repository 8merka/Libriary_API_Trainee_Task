﻿using Libriary_BAL.DTOs;
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
        public async Task<IActionResult> GetAllBooksAsync(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 10)
        {
            var books = await _bookService.GetAllBooksAsync(pageNumber, pageSize, cancellationToken);
            return Ok(books.ToList());
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("{isbn}")]
        [ActionName("GetBookByISBN")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookByISBNAsync([FromRoute] int isbn, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookByISBNAsync(isbn, cancellationToken);
            return Ok(book);
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("id/{id}")]
        [ActionName("GetBookById")]
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
        public async Task<IActionResult> CreateBookAsync([FromBody] BookToCreateDTO bookDTO, CancellationToken cancellationToken = default)
        {
            await _bookService.CreateBookAsync(bookDTO, cancellationToken);
            return Created();
        }
        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [ActionName("UpdateBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBookAsync([FromBody] BookToUpdateDTO bookToUpdateDTO, CancellationToken cancellationToken = default)
        {
            await _bookService.UpdateBookAsync(bookToUpdateDTO, cancellationToken);
            return Ok(bookToUpdateDTO);
        }
        [Authorize(Roles = Roles.Admin)]
        [HttpDelete]
        [ActionName("DeleteBook")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            await _bookService.DeleteBookAsync(id, cancellationToken);
            return Ok();
        }
    }
}
