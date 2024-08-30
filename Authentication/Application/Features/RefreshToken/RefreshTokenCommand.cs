using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Authentication.Application.Features.RefreshToken
{
    public record RefreshTokenCommand: IRequest<RefreshTokenResponse>
    {
        [JsonIgnore]
        public string? AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }

}
