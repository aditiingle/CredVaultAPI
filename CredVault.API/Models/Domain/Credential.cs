namespace CredVault.API.Models.Domain
{
    public class Credential
    {
        public Guid Id { get; set; }
        public string WebsiteName { get; set; }
        public string WebsiteUrl { get; set; }
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }      
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
