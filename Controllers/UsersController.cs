using System.Security.Claims;
using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    JobApplicationContext _context;

    public UsersController(JobApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<User>> Greetings()
    {
        var userName = User.Identity!.Name;
        var user = await _context.Users.SingleOrDefaultAsync(user => user.UserName == userName);
        return Ok(user);
    }
}

