using Turnify.Domain.Entities;

namespace Turnify.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);

        Task<User?> GetByEmailAsync(string email);

        Task AddAsync(User user);
    }
}