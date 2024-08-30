
using FluentValidation;

namespace Authentication.Application.Features.Login
{
    public class LoginValidator: AbstractValidator<LoginCommand>
    {
        public LoginValidator() {

            RuleFor(request => request.Username)
                .NotEmpty()
                .WithMessage("Username is requeired");

            RuleFor(request => request.Password)
                .NotEmpty()
                .WithMessage("Password is requeired");
        }
    }
}
