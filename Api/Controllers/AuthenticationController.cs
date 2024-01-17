using Application.Authentication.Commands.Register;
using Application.Authentication.Common;
using Application.Authentication.Queries.Login;
using Contracts.Authentication;
using MapsterMapper;
using MediatR;

namespace Api.Controllers;

public static class AuthenticationController
{ 
    public static async Task<IResult> Register(RegisterRequest request, ISender sender, IMapper mapper)
    {
        var command = mapper.Map<RegisterCommand>(request);
        var result = await sender.Send(command);
        
        return result.MatchFirst<IResult>(
            authResult => Results.Ok(mapper.Map<AuthenticationResult>(authResult)),
            error => Results.Conflict(error.Description));
    }

    public static async Task<IResult> Login(LoginRequest request, ISender sender, IMapper mapper)
    {
        var query = mapper.Map<LoginQuery>(request);
        var result = await sender.Send(query);
        
        return result.MatchFirst<IResult>(
            authResult => Results.Ok(mapper.Map<AuthenticationResult>(authResult)),
            error => Results.Conflict(error.Description));
        
    }
}