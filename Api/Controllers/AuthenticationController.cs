using Application.Services;
using Contracts.Authentication;

namespace Api.Controllers;

public static class AuthenticationController
{
    public static IResult Register(RegisterRequest request, IAuthenticationService authenticationService)
    {
        var result = authenticationService.Register(request.Username, request.Email, request.Password);

        return result.MatchFirst<IResult>(
            success => Results.Ok(success.ToResponse()),
            error => error.Code switch
            {
                "duplicated_email" or "duplicated_username" => Results.Conflict((object?)error.Description),
                _ => Results.BadRequest((object?)error.Description)
            });
    }

    public static IResult Login(LoginRequest request, IAuthenticationService authenticationService)
    {
        var result = authenticationService.Login(request.Username, request.Password);
        
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