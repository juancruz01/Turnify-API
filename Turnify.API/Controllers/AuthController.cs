using Microsoft.AspNetCore.Mvc;
using Turnify.Application.DTOs.auth;
using Turnify.Application.DTOs.Auth;
using Turnify.Application.Interfaces.Repositories;
using Turnify.Application.Interfaces.Services;
using Turnify.Domain.Entities;
using Turnify.Domain.Enums;

namespace Turnify.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public AuthController(IUserRepository userRepository,
                          IPasswordHasher passwordHasher,
                          ITokenService tokenService) 
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
     
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
        if (existingUser != null) return BadRequest("El email ya está registrado.");

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = _passwordHasher.Hash(dto.Password),
            Role = UserRole.Client
        };

        await _userRepository.AddAsync(user);
        return Ok(new { message = "Usuario registrado exitosamente" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        //Buscar usuario
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null)
        {
            return Unauthorized("Credenciales inválidas."); 
        }

        //Verificar contraseña
        if (!_passwordHasher.Verify(dto.Password, user.PasswordHash))
        {
            return Unauthorized("Credenciales inválidas.");
        }

        //Generar Token
        var token = _tokenService.GenerateToken(user);

        //Retornar Token
        return Ok(new { token });
    }
}