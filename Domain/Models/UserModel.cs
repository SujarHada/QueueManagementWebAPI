using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UserModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class Jwt
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
    }
}
