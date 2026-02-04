using Microsoft.EntityFrameworkCore;
using Turnify.Application.Interfaces.Repositories;
using Turnify.Domain.Entities;
using Turnify.Infrastructure.Persistence;

namespace Turnify.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TurnifyDbContext _context;

    public UserRepository(TurnifyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}