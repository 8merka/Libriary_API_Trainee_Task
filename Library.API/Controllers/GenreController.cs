using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
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
        public async Task<IActionResult> GetAllGenresAsync(CancellationToken cancellationToken)
        {
            var genres = await _genreService.GetAllGenresAsync(cancellationToken);
            return Ok(genres.ToList());
        }

        [HttpPost]
        [ActionName("CreateGenre")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateGenreAsync([FromBody] GenreDTO genreDTO)
        {
            await _genreService.CreateGenreAsync(genreDTO);
            return Created();
        }

        [HttpPut]
        [ActionName("UpdateGenre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGenreAsync([FromBody] GenreToUpdateDTO genreToUpdateDTO)
        {
            await _genreService.UpdateGenreAsync(genreToUpdateDTO);
            return Ok(genreToUpdateDTO);
        }

        [HttpDelete]
        [ActionName("DeleteGenre")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGenreAsync([FromRoute] int id)
        {
            await _genreService.DeleteGenreAsync(id);
            return Ok();
        }
    }
}
