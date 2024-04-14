using Microsoft.AspNetCore.Identity;

namespace Libriary_DAL.Entities.Models
{
    public class User: IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }
    }
}
