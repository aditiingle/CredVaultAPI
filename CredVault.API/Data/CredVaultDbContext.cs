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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var users = new List<User>
            {
                new User
                {
                    Id = Guid.Parse("710b7450-60dc-475c-b783-4bcc094895c7"),
                    Username = "jason.lee",
                    Email = "jason.lee@email.com"
                },

                new User
                {
                    Id = Guid.Parse("a818efb1-28a7-4df9-a655-8ca53ffaf420"),
                    Username = "samantha23",
                    Email = "samantha23@email.com"
                },

                new User
                {
                    Id = Guid.Parse("58e1fd2b-e7b3-475f-a8a1-6f0412bd23c0"),
                    Username = "emma_writer",
                    Email = "emma_writer@email.com"
                },

                new User
                {
                    Id = Guid.Parse("38aa6d36-5f9a-4925-a906-0d2c69193f40"),
                    Username = "mike.dev99",
                    Email = "mike.dev99@email.com"
                },

                new User
                {
                    Id = Guid.Parse("968be66d-6c13-4f92-a9af-cac14c0f6cb4"),
                    Username = "mike.dev99",
                    Email = "mike.dev99@email.com"
                },

            };

            // Add the user data in the database table
            modelBuilder.Entity<User>().HasData(users); 

        }




    }
}
