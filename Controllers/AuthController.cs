using Microsoft.AspNetCore.Mvc;
using projetoAPI.DTOs;
using projetoAPI.Services.Interfaces;

namespace projetoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO request)
    {
        var result = await _authService.RegisterAsync(request);

        if (!result.Success)
            return BadRequest(new { mensagem = result.ErrorMessage });

        return Created("", new { mensagem = "Usuário registrado com sucesso!" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO request)
    {
        var result = await _authService.LoginAsync(request);

        if (!result.Success)
            return Unauthorized(new { mensagem = result.ErrorMessage });

        return Ok(new { token = result.Token });
    }
}
