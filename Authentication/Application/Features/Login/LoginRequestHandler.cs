using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Authentication.Domain.Entities;
using Authentication.Application.Interfaces.Repostories;
using Authentication.Application.Interfaces.Services;
using Authentication.Domain.Models;

namespace Authentication.Application.Features.Login
{
    public class LoginRequestHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IAuthenticateRepository _repo;

        private readonly ITokenService _tokenService;

        private readonly LoginValidator validator = new LoginValidator();

        public LoginRequestHandler(IAuthenticateRepository repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await GetUser(request.Username, request.Password);
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshTokenForUser(user);

            await _repo.SaveRefreshTokenForUserAync(refreshToken, user);

            return new LoginResponse(accessToken, refreshToken.Token);
        }

        private async Task<User> GetUser(string username, string password)
        {
            var user = await _repo.GetUserByUsernameAsync(username);

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            string encryptedPassword = Convert.ToBase64String(plainTextBytes);

            if (user == null && user.EncryptedPassword != encryptedPassword)
            {
                throw new AppException("Username or Password is incorrect", HttpStatusCode.BadRequest);
            }

            return user;
        }
    }
}
