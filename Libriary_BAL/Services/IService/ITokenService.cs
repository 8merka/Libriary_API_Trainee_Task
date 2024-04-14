using System.Security.Claims;
using Libriary_BAL.DTOs;
using Libriary_DAL.Entities.Models;


namespace Libriary_BAL.Services.IService
{
    public interface ITokenService
    {
        string GenerateToken(IEnumerable<Claim> claims);
        Task<TokenDTO> CreateTokenAsync(User user, bool Exp);
        Task<TokenDTO> RefreshTokenAsync(TokenDTO tokenDto, CancellationToken cancellationToken);
    }
}
