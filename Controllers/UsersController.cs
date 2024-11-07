using System.IdentityModel.Tokens.Jwt;
using JobApplicationTracker.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly JobApplicationContext _context;
    public UsersController(JobApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<string> Greetings()
    {
        var userId = HttpContext.User;
        return Ok(HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value);
    }
}

