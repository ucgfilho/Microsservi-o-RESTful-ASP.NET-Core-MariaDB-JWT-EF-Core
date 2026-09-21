using projetoAPI.DTOs;

namespace projetoAPI.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterDTO dto);
    Task<AuthResult> LoginAsync(LoginDTO dto);
}
