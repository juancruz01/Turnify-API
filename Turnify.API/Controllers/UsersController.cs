using Microsoft.AspNetCore.Mvc;
using Turnify.Application.Interfaces.Repositories;
using Turnify.Domain.Entities;

namespace Turnify.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository; 
    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userRepository.GetAllAsync();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        // La lógica de negocio básica (como la fecha) idealmente iría en un Servicio,
        user.CreatedAt = DateTime.UtcNow;

        await _userRepository.AddAsync(user);

        return CreatedAtAction(nameof(GetAll), new { id = user.Id }, user);
    }
}