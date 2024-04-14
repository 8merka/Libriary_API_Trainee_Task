﻿using Libriary_BAL.DTOs;
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

        [Authorize(Roles = Roles.User)]
        [HttpGet]
        [ActionName("GetAllAuthors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAuthorsAsync(CancellationToken cancellationToken)
        {
            var authors = await _authorService.GetAllAuthorsAsync(cancellationToken);
            return Ok(authors.ToList());
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [ActionName("CreateAuthor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] AuthorDTO authorDTO)
        {
            await _authorService.CreateAuthorAsync(authorDTO);
            return Created();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [ActionName("UpdateAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] AuthorToUpdateDTO authorToUpdateDTO)
        {
            await _authorService.UpdateAuthorAsync(authorToUpdateDTO);
            return Ok(authorToUpdateDTO);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete]
        [ActionName("DeleteAuthor")]
        [Route("{id}")]
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
