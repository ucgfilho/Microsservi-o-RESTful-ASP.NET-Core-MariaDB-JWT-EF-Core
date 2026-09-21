namespace projetoAPI.DTOs;

public record AuthResult(bool Success, string? Token = null, string? ErrorMessage = null);
