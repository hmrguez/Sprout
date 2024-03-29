using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
public abstract class ApiController: ControllerBase
{
    protected IActionResult Error(Error error)
    {
        return error.Type switch {
            ErrorType.NotFound => NotFound(error.Description),
            ErrorType.Conflict => Conflict(error.Description),
            ErrorType.Unauthorized => Unauthorized(error.Description),
            _ => BadRequest(error.Description),
        };
    }
    
}