namespace Application.Services.Authentication.Common;

public record AuthenticationResult(
    Guid Id,
    string Username,
    string Email,
    string Token); 