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

    public AuthController(IUserService userService)
    {
        _userService = userService;
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
            token => Ok(token),
            validationFailed => BadRequest(validationFailed.MapToResponse())
        );
    }

}