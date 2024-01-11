using Application.Services;
using Contracts.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public static class AuthenticationController
{
    public static IResult Register(RegisterRequest request, IAuthenticationService authenticationService)
    {
        var result = authenticationService.Register(request.Username, request.Password);

        var response = new AuthenticationResponse(result.Id, result.Username, result.Email, result.Token);
        
        return Results.Ok(response);
    }
    
    public static IResult Login(LoginRequest request, IAuthenticationService authenticationService)
    {
        var result = authenticationService.Login(request.Username, request.Password);
        var response = new AuthenticationResponse(result.Id, result.Username, result.Email, result.Token);

        return Results.Ok(response);
    }
}