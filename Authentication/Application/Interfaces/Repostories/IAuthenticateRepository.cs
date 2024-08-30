using Authentication.Domain.Entities;
using Authentication.Domain.Models;

namespace Authentication.Application.Interfaces.Repostories
{
    public interface IAuthenticateRepository
    {
        Task RegisterUserAsync(User user);
        Task<bool> UserExistsAsync(string email);
        Task<User?> GetUserByUsernameAsync(string username);
        Task SaveRefreshTokenForUserAync(RefreshToken refreshToken, User user);
    }
}
