namespace Application.Services;

public class AuthenticationService: IAuthenticationService
{
    public AuthenticationResult Register(string username, string password)
    {
        return new AuthenticationResult( 
            new Guid(),
            username,
            username + "@example.com",
            "token");
    }

    public AuthenticationResult Login(string username, string password)
    {
        return new AuthenticationResult(
            new Guid(),
            username,
            username + "@example.com",
            "token");
    }
}