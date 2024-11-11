using JobApplicationTracker.Contracts.Requests;
using JobApplicationTracker.Extensions;
using Microsoft.AspNetCore.Mvc;
using JobApplicationTracker.Models;
using JobApplicationTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JobApplicationTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobApplicationsController : ControllerBase
{
    private readonly IJobApplicationService _jobApplicationService;

    public JobApplicationsController(IJobApplicationService jobApplicationService)
    {
        _jobApplicationService = jobApplicationService;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobApplication>>> GetUsersApplications()
    {
        var userId = HttpContext.User.GetUserId();
        var jobApplications = await _jobApplicationService.GetUsersApplications(userId);
        return Ok(jobApplications);
    }
    
    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<JobApplication>> GetJobApplication(Guid id)
    {
        var jobApplication = await _jobApplicationService.GetById(id);

        if (jobApplication == null)
        {
            return NotFound();
        }

        return Ok(jobApplication);
    }
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<JobApplication>> CreateJobApplication([FromBody]CreateJobApplicationRequest request)
    {
        var userId = HttpContext.User.GetUserId();
        
        var createdId = await _jobApplicationService.CreateJobApplication(userId, request);

        return CreatedAtAction("GetJobApplication", new { id = createdId }, createdId);
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateJobApplication(Guid id, [FromBody]JobApplication jobApplication)
    {
        if (id != jobApplication.Id)
        {
            return BadRequest();
        }
        
        var userId = HttpContext.User.GetUserId();

        var updatedId = await _jobApplicationService.UpdateJobApplication(jobApplication, userId);
        return Ok(updatedId);
    }
    
    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteJobApplication(Guid id)
    {
        var userId = HttpContext.User.GetUserId();
        var result = await _jobApplicationService.DeleteJobApplication(id, userId);
        return result.Match<IActionResult>
        (
            guid => Ok(guid),
            jobApplicationDoesNotExist => BadRequest(jobApplicationDoesNotExist.Description),
            authorizationEditError => Unauthorized(authorizationEditError.Description)
        );
    }
}

