using JobApplicationTracker.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
    {
        return Ok();
    }

}