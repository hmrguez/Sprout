using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;

namespace Application.Services;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IAuthenticationService
{
    public AuthenticationResult Register(string username, string email, string password)
    {
        if (userRepository.GetUserByUsername(username) != null)
            throw new Exception("Username already exists");

        if (userRepository.GetUserByEmail(email) != null)
            throw new Exception("Email already exists");

        var user = new User()
        {
            Username = username,
            Email = email,
            Password = password
        };
        
        userRepository.Add(user);
        
        var token = jwtTokenGenerator.GenerateToken(user.Id, username, email);
        return new AuthenticationResult(user.Id, username, email, token);
    }

    public AuthenticationResult Login(string username, string password)
    {
        if(userRepository.GetUserByUsername(username) is not { } user)
            throw new Exception("User not found");
        
        if(user.Password != password)
            throw new Exception("Invalid password");
        
        var token = jwtTokenGenerator.GenerateToken(user.Id, username, user.Email);
        return new AuthenticationResult(user.Id, user.Username, user.Email, token);
    }
}