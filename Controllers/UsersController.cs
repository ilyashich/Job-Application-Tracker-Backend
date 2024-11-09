using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public ActionResult<string> Greetings()
    {
        var userId = HttpContext.User;
        //HttpContext.Response.Cookies.Append();
        return Ok(HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value);
    }
}

