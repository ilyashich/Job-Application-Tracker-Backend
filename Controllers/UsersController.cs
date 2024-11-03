using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public ActionResult Greetings(ClaimsPrincipal user)
    {
        return Ok($"Hello, {user.Identity!.Name}");
    }
}

