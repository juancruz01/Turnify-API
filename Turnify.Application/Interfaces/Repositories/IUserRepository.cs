using Turnify.Domain.Entities;

namespace Turnify.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
    }
}