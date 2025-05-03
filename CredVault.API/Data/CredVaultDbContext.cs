using Microsoft.EntityFrameworkCore;
using CredVault.API.Models.Domain;

namespace CredVault.API.Data
{
    public class CredVaultDbContext: DbContext
    {
        public CredVaultDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) // Passing param to base class
        {
            
        }

        // DB Sets represent tables or collections inside the database.
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        

    }
}
