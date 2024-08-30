
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Authentication.Domain.Entities
{
    public class User
    {
        [Column(name: "user_id")]
        public int UserId { get; set; }

        [Column(name: "username")]
        public string Username { get; set; }

        [Column(name: "encrypted_password")]
        public string EncryptedPassword { get; set; }

        [Column(name: "email")]
        public string Email { get; set; }

        [Column(name: "role")]
        public string Role { get; set; }

        [Column(name: "refresh_token")]
        public string? RefreshToken { get; set; }

        [Column(name: "expire_date", TypeName = "timestamp without time zone")]
        public DateTime? ExpireDate { get; set; }
    }
}
