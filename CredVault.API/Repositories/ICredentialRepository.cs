using CredVault.API.Models.Domain;

namespace CredVault.API.Repositories
{
    public interface ICredentialRepository
    {
        Task<Credential> CreateCredentialAsync(Credential credential);
        Task<List<Credential>> GetAllCredentialsAsync();
        Task<Credential?> GetCredentialByIdAsync(Guid id);
        Task<Credential?> UpdateCredentialAsync(Guid id, Credential credential);
        Task<Credential?> DeleteCredentialAsync(Guid id);

    }
}
