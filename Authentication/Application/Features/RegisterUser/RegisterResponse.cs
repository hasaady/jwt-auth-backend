
namespace Authentication.Application.Features.RegisterUser
{
    public class RegisterResponse
    {
        string Message { get; set; }

        public RegisterResponse(string message)
        {
            Message = message;
        }
    }
}
