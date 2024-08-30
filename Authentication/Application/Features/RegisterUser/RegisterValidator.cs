
using FluentValidation;

namespace Authentication.Application.Features.RegisterUser
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(request => request.UserName)
                .NotEmpty()
                .WithMessage("UserName is requied");
           
            RuleFor(request => request.Password)
                .NotEmpty()
                .WithMessage("Password is requied");
           
            RuleFor(request => request.Email)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("Email is requied");
        }
    }
}