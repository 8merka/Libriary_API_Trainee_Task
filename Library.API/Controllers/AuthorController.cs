using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace Libriary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IAuthorService authorService) : ControllerBase
    {
        private readonly IAuthorService _authorService = authorService;

        [HttpGet]
        [Route("GetAllAuthors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAuthorsAsync(CancellationToken cancellationToken)
        {
            var authors = await _authorService.GetAllAuthorsAsync(cancellationToken);
            return Ok(authors.ToList());
        }

        [HttpPost]
        [Route("CreateAuthor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] AuthorDTO authorDTO)
        {
            await _authorService.CreateAuthorAsync(authorDTO);
            return Created();
        }

        [HttpPut]
        [Route("UpdateAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] AuthorToUpdateDTO authorToUpdateDTO)
        {
            await _authorService.UpdateAuthorAsync(authorToUpdateDTO);
            return Ok(authorToUpdateDTO);
        }

        [HttpDelete]
        [Route("DeleteAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAuthorAsync(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return Ok();
        }
    }
}
