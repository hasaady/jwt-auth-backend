using Authentication.Application.Features.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Features.Login
{
    public record LoginCommand(string Username, string Password) : IRequest<LoginResponse>;

}
