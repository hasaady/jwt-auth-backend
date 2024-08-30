using MediatR;
using System.Net;
using Authentication.Application.Features.Login;
using Authentication.Domain.Entities;
using Authentication.Application.Interfaces.Repostories;
using Authentication.Application.Interfaces.Services;
using Authentication.Domain.Models;

namespace Authentication.Application.Features.RefreshToken
{
    public class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
    {
        private readonly IAuthenticateRepository _repo;
        private readonly ITokenService _tokenService;

        public RefreshTokenRequestHandler(IAuthenticateRepository repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            var username = principal.Identity.Name;

            var user = await _repo.GetUserByUsernameAsync(username);

            if (user == null)
            {
                throw new AppException("Invalid User", HttpStatusCode.BadRequest);
            }

            if (user.RefreshToken != request.RefreshToken || user.ExpireDate <= DateTime.UtcNow)
            {
                throw new AppException("Invalid refresh token", HttpStatusCode.BadRequest);
            }

            var newAccessToken = _tokenService.GenerateAccessToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshTokenForUser(user);
            await _repo.SaveRefreshTokenForUserAync(newRefreshToken, user);

            return new RefreshTokenResponse(newAccessToken, newRefreshToken.Token);
        }
    }
}
