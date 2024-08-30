using Authentication.Application.Features.RegisterUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Features.RegisterUser
{
    public record RegisterCommand(string UserName, string Password, string Email) : IRequest<RegisterResponse>;

}
