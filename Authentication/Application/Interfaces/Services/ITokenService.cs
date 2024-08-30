using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authentication.Domain.Entities;
using Authentication.Domain.Models;

namespace Authentication.Application.Interfaces.Services
{
    public interface ITokenService
    {
        public string GenerateAccessToken(User user);
        public RefreshToken GenerateRefreshTokenForUser(User user);
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
