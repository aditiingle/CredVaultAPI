using CredVault.API.Models.Domain;

namespace CredVault.API.Repositories

{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        // User can be nullable
        Task<User?> GetUserByIdAsync(Guid id);

        Task<User> CreateUserAsync(User user);

        Task<User?> UpdateUserAsync(Guid id, User user);

        Task<User?> DeleteUserAsync(Guid id);


    }
}
