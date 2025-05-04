using CredVault.API.Data;
using CredVault.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CredVault.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CredVaultDbContext dbContext;

        // Inject the DBContext class in the repository
        public UserRepository(CredVaultDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CredVaultDbContext DbContext { get; }

        public async Task<User> CreateUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteUserAsync(Guid id)
        {
            var retrievedUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (retrievedUser == null)
            {
                return null;
            }

            dbContext.Users.Remove(retrievedUser); // Not an asynchronous method
            await dbContext.SaveChangesAsync();

            return retrievedUser;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync(); // Retrieve data from the database
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> UpdateUserAsync(Guid id, User user)
        {
            var retrievedUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (retrievedUser == null)
            {
                return null;
            }

            retrievedUser.Username = user.Username;
            retrievedUser.Email = user.Email;

            await dbContext.SaveChangesAsync();

            return retrievedUser;



        }
    }
}
