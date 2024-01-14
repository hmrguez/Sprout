using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using Domain.Errors;
using ErrorOr;

namespace Application.Services;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IAuthenticationService
{
    public ErrorOr<AuthenticationResult> Register(string username, string email, string password)
    {
        if (userRepository.GetUserByUsername(username) != null)
            return Errors.Auth.DuplicatedUsername;

        if (userRepository.GetUserByEmail(email) != null)
            return Errors.Auth.DuplicatedEmail;

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

    public ErrorOr<AuthenticationResult> Login(string username, string password)
    {
        if (userRepository.GetUserByUsername(username) is not { } user)
            return Errors.Auth.UserNotFound;

        if (user.Password != password)
            return Errors.Auth.WrongPassword;

        var token = jwtTokenGenerator.GenerateToken(user.Id, username, user.Email);
        return new AuthenticationResult(user.Id, user.Username, user.Email, token);
    }
}