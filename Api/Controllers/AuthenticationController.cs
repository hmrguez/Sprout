using Application.Authentication.Commands.Register;
using Application.Authentication.Queries.Login;
using Application.Services.Authentication.Common;
using Contracts.Authentication;
using MediatR;

namespace Api.Controllers;

public static class AuthenticationController
{ 
    public static async Task<IResult> Register(RegisterRequest request, ISender sender)
    {
        var command = new RegisterCommand(request.Username, request.Email, request.Password);
        var result = await sender.Send(command);
        
        return result.MatchFirst<IResult>(
            success => Results.Ok(success.ToResponse()),
            error => error.Code switch
            {
                "duplicated_email" or "duplicated_username" => Results.Conflict((object?)error.Description),
                _ => Results.BadRequest((object?)error.Description)
            });
    }

    public static async Task<IResult> Login(LoginRequest request, ISender sender)
    {
        var query = new LoginQuery(request.Username, request.Password);
        var result = await sender.Send(query);
        
        return result.MatchFirst<IResult>(
            success => Results.Ok(success.ToResponse()),
            error => error.Code switch
            {
                "user_not_found" => Results.NotFound(error.Description),
                "wrong_password" => Results.Problem(statusCode: StatusCodes.Status403Forbidden, detail: error.Description),
                _ => Results.BadRequest(error.Description)
            });
        
    }

    private static AuthenticationResponse ToResponse(this AuthenticationResult result)
    {
        return new AuthenticationResponse(result.Id, result.Username, result.Email, result.Token);
    }
}