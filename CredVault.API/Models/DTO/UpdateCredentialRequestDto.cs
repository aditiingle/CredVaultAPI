namespace CredVault.API.Models.DTO
{
    public class UpdateCredentialRequestDto
    {
        public string WebsiteName { get; set; }
        public string WebsiteUrl { get; set; }
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }

        public Guid UserId { get; set; }
    }
}
