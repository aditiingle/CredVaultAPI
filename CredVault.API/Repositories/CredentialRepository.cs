using CredVault.API.Data;
using CredVault.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CredVault.API.Repositories
{
    public class CredentialRepository : ICredentialRepository
    {
        private readonly CredVaultDbContext dbContext;

        public CredentialRepository(CredVaultDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Credential> CreateCredentialAsync(Credential credential)
        {
            await dbContext.Credentials.AddAsync(credential);
            await dbContext.SaveChangesAsync();
            return credential;
        }

        public async Task<Credential?> DeleteCredentialAsync(Guid id)
        {
            var retrievedCredential = await dbContext.Credentials.FirstOrDefaultAsync(x => x.Id == id);

            if (retrievedCredential == null)
            {
                return null;
            }

            dbContext.Credentials.Remove(retrievedCredential);

            await dbContext.SaveChangesAsync();

            return (retrievedCredential);
        }

        public async Task<List<Credential>> GetAllCredentialsAsync()
        {
            return await dbContext.Credentials.Include("User").ToListAsync();
        }

        public async Task<Credential?> GetCredentialByIdAsync(Guid id)
        {
            return await dbContext.Credentials.Include("User").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Credential?> UpdateCredentialAsync(Guid id, Credential credential)
        {
            var retrievedCredential = await dbContext.Credentials.FirstOrDefaultAsync(x => x.Id == id);

            if (retrievedCredential == null)
            {
                return null;
            }

            retrievedCredential.WebsiteName = credential.WebsiteName;
            retrievedCredential.WebsiteUrl = credential.WebsiteUrl;
            retrievedCredential.UsernameOrEmail = credential.UsernameOrEmail;
            retrievedCredential.Password = credential.Password;
            retrievedCredential.UserId = credential.UserId;

            await dbContext.SaveChangesAsync();

            return retrievedCredential;
        }


    }
}
