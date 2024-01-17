using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Errors;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.Login;

public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (userRepository.GetUserByUsername(query.Username) is not { } user)
            return Errors.Auth.UserNotFound;

        if (user.Password != query.Password)
            return Errors.Auth.WrongPassword;

        var token = jwtTokenGenerator.GenerateToken(user.Id, query.Username, user.Email);
        return new AuthenticationResult(user.Id, user.Username, user.Email, token);
    }
}