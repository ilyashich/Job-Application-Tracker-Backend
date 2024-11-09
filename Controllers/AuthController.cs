using JobApplicationTracker.Dtos.Requests;
using JobApplicationTracker.Extensions;
using JobApplicationTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest registerRequest)
    {
        var result = await _userService.Register(registerRequest);
        return result.Match<IActionResult>
        (
            newUser => Ok(newUser.MapToResponse()),
            validationFailed => BadRequest(validationFailed.MapToResponse())
        );
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest loginRequest)
    {
        var result = await _userService.Login(loginRequest);
        return result.Match<IActionResult>
        (
            token =>
            {
                HttpContext.Response.Cookies.Append(_configuration["JwtOptions:CookieName"]!,token);
                return Ok();
            },
            validationFailed => BadRequest(validationFailed.MapToResponse())
        );
    }
    
    [HttpPost("logout")]
    [Authorize]
    public IActionResult Logout()
    {
        HttpContext.Response.Cookies.Delete(_configuration["JwtOptions:CookieName"]!);

        return Ok("Logged out successfully.");
    }

}