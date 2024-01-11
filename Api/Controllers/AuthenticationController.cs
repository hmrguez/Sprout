using Contracts.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public static class AuthenticationController
{
    public static IResult Register(RegisterRequest request)
    {
        return Results.Ok(request);
    }
    
    public static IResult Login(LoginRequest request)
    {
        return Results.Ok(request);
    }
}