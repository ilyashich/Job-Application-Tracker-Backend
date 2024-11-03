using JobApplicationTracker.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
    {
        
    }

}