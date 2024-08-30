using System.Net;
using System.Text.Json;

namespace Authentication.Domain.Models
{
    public class AppException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public AppException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class AppError
    {
        public string Message { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
