using projetoAPI.DTOs;
using projetoAPI.Models;
using projetoAPI.Repositories.Interfaces;
using projetoAPI.Services.Interfaces;

namespace projetoAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IUserRepository userRepository, ITokenService tokenService, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResult> RegisterAsync(RegisterDTO dto)
    {
        if (await _userRepository.EmailExistsAsync(dto.Email))
            return new AuthResult(false, ErrorMessage: "Este e-mail já está em uso.");

        var user = new User
        {
            Email = dto.Email,
            Password = _passwordHasher.Hash(dto.Password)
        };

        await _userRepository.AddAsync(user);
        return new AuthResult(true);
    }

    public async Task<AuthResult> LoginAsync(LoginDTO dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);

        if (user == null)
            return new AuthResult(false, ErrorMessage: "E-mail ou senha inválidos.");

        if (!_passwordHasher.Verify(dto.Password, user.Password))
            return new AuthResult(false, ErrorMessage: "E-mail ou senha inválidos.");

        var token = _tokenService.GenerateToken(user);
        return new AuthResult(true, Token: token);
    }
}
