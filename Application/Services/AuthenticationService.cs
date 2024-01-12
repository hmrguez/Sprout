using Application.Common.Interfaces.Authentication;

namespace Application.Services;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
{
    public AuthenticationResult Register(string username, string password)
    {
        var userId = new Guid(); // Temp
        var email = username + "@example.com"; // Temp

        var token = jwtTokenGenerator.GenerateToken(userId, username, email);
        return new AuthenticationResult(userId, username, email, token);
    }

    public AuthenticationResult Login(string username, string password)
    {
        
        var userId = new Guid(); // Temp
        var email = username + "@example.com"; // Temp

        var token = jwtTokenGenerator.GenerateToken(userId, username, email);
        return new AuthenticationResult(userId, username, email, token);
    }
}