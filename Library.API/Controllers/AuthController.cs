using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService authenticationService) : ControllerBase
    {
        private readonly IAuthService _authenticationService = authenticationService;

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO login, CancellationToken cancellationToken = default)
        {
            var tokens = await _authenticationService.AuthAsync(login, cancellationToken);

            return Ok(tokens);
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO register, CancellationToken cancellationToken = default)
        {
            await _authenticationService.RegAsync(register, cancellationToken);

            return Created();
        }
    }

}
