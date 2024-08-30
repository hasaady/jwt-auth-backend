
using FluentValidation;

namespace Authentication.Application.Features.RefreshToken
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenValidator()
        {
            RuleFor(request => request.RefreshToken)
                .NotEmpty()
                .WithMessage("Refresh token is required");

            RuleFor(request => request.AccessToken)
                .NotNull()
                .NotEmpty()
                .WithMessage("Access token is required");
        }
    }
}