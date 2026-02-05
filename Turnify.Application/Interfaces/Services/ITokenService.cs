using Turnify.Domain.Entities;

namespace Turnify.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}