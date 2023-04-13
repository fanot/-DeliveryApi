using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class Logout
    {
        public string Email { get; set; } = "user@example.com";

        public string Password { get; set; } = "funny1cool";
    }
}
