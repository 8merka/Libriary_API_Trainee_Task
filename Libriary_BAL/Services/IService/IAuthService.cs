using Libriary_BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Services.IService
{
    public interface IAuthService
    {
        Task<TokenDTO?> AuthAsync(LoginDTO loginCredentials, CancellationToken token);
        Task<bool> RegAsync(RegisterDTO registerCredentials, CancellationToken token);
    }
}
