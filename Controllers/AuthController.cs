using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using projetoAPI.Data;
using projetoAPI.DTOs;
using projetoAPI.Models;

namespace projetoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDTO request)
    {
        var emailExiste = _context.Usuarios.Any(u => u.Email == request.Email);
        
        if (emailExiste)
            return BadRequest(new { mensagem = "Este e-mail já está em uso." });

        var novoUsuario = new Usuario
        {
            Email = request.Email,
            Senha = BCrypt.Net.BCrypt.HashPassword(request.Senha)
        };

        _context.Usuarios.Add(novoUsuario);
        _context.SaveChanges();

        return Created("", new { mensagem = "Usuário registrado com sucesso!" });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO request)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == request.Email);

        if (usuario == null)
            return Unauthorized(new { mensagem = "E-mail ou senha inválidos." });

        bool senhaValida = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.Senha);

        if (!senhaValida)
            return Unauthorized(new { mensagem = "E-mail ou senha inválidos." });

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return Ok(new { token = tokenString });
    }
}
