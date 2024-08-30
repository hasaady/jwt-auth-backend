using MediatR;
using System.Net;
using Authentication.Domain.Entities;
using Authentication.Domain.Enuma;
using Authentication.Application.Interfaces.Repostories;
using Authentication.Domain.Models;

namespace Authentication.Application.Features.RegisterUser
{
    public class RegisterRequestHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly IAuthenticateRepository _repo;

        public RegisterRequestHandler(IAuthenticateRepository repo)
        {
            _repo = repo;
        }
        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            if (await _repo.UserExistsAsync(request.Email))
            {
                throw new AppException("Already Registerd", HttpStatusCode.BadRequest);
            }
            else
            {
                User user = new User
                {
                    Username = request.UserName,
                    Email = request.Email,
                    Role = UserRole.User
                };

                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(request.Password);
                user.EncryptedPassword = Convert.ToBase64String(plainTextBytes);

                await _repo.RegisterUserAsync(user);
                return new RegisterResponse("Registerd Successfully");
            }
        }
    }
}