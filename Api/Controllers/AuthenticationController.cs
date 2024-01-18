using Application.Authentication.Commands.Register;
using Application.Authentication.Common;
using Application.Authentication.Queries.Login;
using Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[AllowAnonymous]
[Route("auth")]
public class AuthenticationController(ISender sender, IMapper mapper): ApiController
{ 
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request);
        var result = await sender.Send(command);
        return result.MatchFirst<IActionResult>(authResult => Ok(mapper.Map<AuthenticationResult>(authResult)), Error);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var query = mapper.Map<LoginQuery>(request);
        var result = await sender.Send(query);
        return result.MatchFirst<IActionResult>(authResult => Ok(mapper.Map<AuthenticationResult>(authResult)), Error);
    }
}