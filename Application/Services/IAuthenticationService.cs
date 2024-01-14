using FluentResults;

namespace Application.Services;

public interface IAuthenticationService
{
    Result<AuthenticationResult> Register(string username, string email, string password);
    AuthenticationResult Login(string username, string password);
}