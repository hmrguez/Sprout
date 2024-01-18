using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("courses")]
public class CoursesController: ApiController
{
    [HttpGet]
    public IActionResult GetCourses()
    {
        return Ok(Array.Empty<string>());
    }
}