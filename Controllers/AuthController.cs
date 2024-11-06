using System.ComponentModel.DataAnnotations;
using JobApplicationTracker.Dtos;
using JobApplicationTracker.Dtos.Requests;
using JobApplicationTracker.Extensions;
using JobApplicationTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using OneOf.Types;

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
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        var user = request.MapToUser();
        var result = await _userService.Register(user);
        return result.Match<IActionResult>(
            newUser => Ok(newUser),
            validationError => BadRequest(validationError)
        );
    }

}