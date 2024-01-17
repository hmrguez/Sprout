using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using Domain.Errors;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.Register;

public class RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (userRepository.GetUserByUsername(command.Username) != null)
            return Errors.Auth.DuplicatedUsername;

        if (userRepository.GetUserByEmail(command.Email) != null)
            return Errors.Auth.DuplicatedEmail;

        var user = new User()
        {
            Username = command.Username,
            Email = command.Email,
            Password = command.Password
        };

        userRepository.Add(user);

        var token = jwtTokenGenerator.GenerateToken(user.Id, command.Username, command.Email);
        return new AuthenticationResult(user.Id, command.Username, command.Email, token);
    }
}