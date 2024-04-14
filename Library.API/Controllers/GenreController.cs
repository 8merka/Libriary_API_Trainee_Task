using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
using Libriary_BAL.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController(IGenreService genreService) : ControllerBase
    {
        private readonly IGenreService _genreService = genreService;


        [HttpGet]
        [ActionName("GetAllGenres")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllGenresAsync(CancellationToken cancellationToken, int pageNumber = 1, int pagesize = 10)
        {
            var genres = await _genreService.GetAllGenresAsync(pageNumber, pagesize, cancellationToken);
            return Ok(genres.ToList());
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [ActionName("CreateGenre")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateGenreAsync([FromBody] GenreDTO genreDTO, CancellationToken cancellationToken = default)
        {
            await _genreService.CreateGenreAsync(genreDTO, cancellationToken);
            return Created();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [ActionName("UpdateGenre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGenreAsync([FromBody] GenreToUpdateDTO genreToUpdateDTO, CancellationToken cancellationToken = default)
        {
            await _genreService.UpdateGenreAsync(genreToUpdateDTO, cancellationToken);
            return Ok(genreToUpdateDTO);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete]
        [ActionName("DeleteGenre")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGenreAsync([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            await _genreService.DeleteGenreAsync(id, cancellationToken);
            return Ok();
        }
    }
}
