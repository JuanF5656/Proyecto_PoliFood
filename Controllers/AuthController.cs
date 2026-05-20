using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;
using Polifood.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(IAuthService authService, UserManager<IdentityUser> userManager)
    {
        _authService = authService;
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {
        var result = await _authService.Register(model.Email, model.Password, model.Role);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            return Ok(new
            {
                Message = $"Usuario {model.Email} creado con éxito.",
                UserId = user!.Id
            });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        var token = await _authService.Login(model.Email, model.Password);

        if (token != null)
        {
            // Obtenemos el rol real del usuario desde Identity
            var user = await _userManager.FindByEmailAsync(model.Email);
            var roles = await _userManager.GetRolesAsync(user!);
            var role = roles.FirstOrDefault() ?? "Student";

            return Ok(new
            {
                Token = token,
                Role = role,
                Email = model.Email
            });
        }

        return Unauthorized(new { Message = "Credenciales incorrectas." });
    }
}