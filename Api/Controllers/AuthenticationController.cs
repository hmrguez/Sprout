using Application.Common.Errors;
using Application.Services;
using Contracts.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public static class AuthenticationController
{
    public static IResult Register(RegisterRequest request, IAuthenticationService authenticationService)
    {
        var result = authenticationService.Register(request.Username, request.Email, request.Password);
        
        if (result.IsSuccess)
            return Results.Ok(result.Value.ToResponse());

        var firstError = result.Errors[0];
        return firstError switch
        {
            DuplicateEmailError => Results.Conflict(firstError.Message),
            DuplicateUsernameError => Results.Conflict(firstError.Message),
            _ => Results.BadRequest(firstError.Message)
        };
    }
    
    public static IResult Login(LoginRequest request, IAuthenticationService authenticationService)
    {
        var result = authenticationService.Login(request.Username, request.Password);
        var response = new AuthenticationResponse(result.Id, result.Username, result.Email, result.Token);

        return Results.Ok(response);
    }
    
    private static AuthenticationResponse ToResponse(this AuthenticationResult result)
    {
        return new AuthenticationResponse(result.Id, result.Username, result.Email, result.Token);
    }
}