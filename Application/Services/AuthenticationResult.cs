namespace Application.Services;

public record AuthenticationResult(
    Guid Id,
    string Username,
    string Email,
    string Token); 