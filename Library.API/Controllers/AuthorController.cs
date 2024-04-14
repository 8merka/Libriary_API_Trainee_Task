using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
using Libriary_BAL.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController(IAuthorService authorService) : ControllerBase
    {
        private readonly IAuthorService _authorService = authorService;

        [HttpGet]
        [ActionName("GetAllAuthors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAuthorsAsync(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 10)
        {
            var authors = await _authorService.GetAllAuthorsAsync(pageNumber, pageSize, cancellationToken);
            return Ok(authors.ToList());
        }


        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [ActionName("CreateAuthor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] AuthorDTO authorDTO, CancellationToken cancellationToken = default)
        {
            await _authorService.CreateAuthorAsync(authorDTO, cancellationToken);
            return Created();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [ActionName("UpdateAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] AuthorToUpdateDTO authorToUpdateDTO, CancellationToken cancellationToken = default)
        {
            await _authorService.UpdateAuthorAsync(authorToUpdateDTO, cancellationToken);
            return Ok(authorToUpdateDTO);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete]
        [ActionName("DeleteAuthor")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAuthorAsync([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            await _authorService.DeleteAuthorAsync(id, cancellationToken);
            return Ok();
        }
    }
}
