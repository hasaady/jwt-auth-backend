
namespace Authentication.Application.Features.Login
{
    public class LoginResponse
    {
        public string AccessToken {  get; set; }
        public string RefreshToken { get; set; }

        public LoginResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
