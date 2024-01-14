using ErrorOr;

namespace Application.Services;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(string username, string email, string password);
    ErrorOr<AuthenticationResult> Login(string username, string password);
}