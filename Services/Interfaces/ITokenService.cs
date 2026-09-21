using projetoAPI.Models;

namespace projetoAPI.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
