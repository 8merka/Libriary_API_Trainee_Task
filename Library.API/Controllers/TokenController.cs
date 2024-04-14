using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController(ITokenService tokenService) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost]
        [Route("refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] TokenDTO tokenDTO, CancellationToken token = default)
        {
            var tokens = await _tokenService.RefreshTokenAsync(tokenDTO, token);

            return Ok(tokens);
        }
    }

}
