namespace Application.Services;

public interface IAuthenticationService
{
    AuthenticationResult Register(string username, string email, string password);
    AuthenticationResult Login(string username, string password);
}