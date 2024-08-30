using Authentication.Domain.Entities;
using Authentication.Application.Interfaces.Repostories;
using Authentication.Infrastructure.Data.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Authentication.Domain.Models;

namespace Authentication.Infrastructure.Repositories
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthenticateRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RegisterUserAsync(User user)
        {
            await _dbContext.users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            return await _dbContext.users.AnyAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.users.FirstOrDefaultAsync(user =>
                user.Username == username
            );
        }

        public async Task SaveRefreshTokenForUserAync(RefreshToken refreshToken, User user)
        {
            user.RefreshToken = refreshToken.Token;
            user.ExpireDate = refreshToken.ExpireDate;
            await _dbContext.SaveChangesAsync();
        }
    }
}
