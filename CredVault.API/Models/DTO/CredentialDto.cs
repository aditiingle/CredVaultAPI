using CredVault.API.Models.Domain;

namespace CredVault.API.Models.DTO
{
    public class CredentialDto
    {
        public Guid Id { get; set; }
        public string WebsiteName { get; set; }
        public string WebsiteUrl { get; set; }
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }

        public UserDto User { get; set; }
    }
}
