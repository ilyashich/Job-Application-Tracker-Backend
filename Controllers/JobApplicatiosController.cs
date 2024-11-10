using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApplicationTracker.Models;
using JobApplicationTracker.Services;

namespace JobApplicationTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobApplicationsController : ControllerBase
{
    private readonly JobApplicationService _jobApplicationService;

    public JobApplicationsController(JobApplicationService jobApplicationService)
    {
        _jobApplicationService = jobApplicationService;
    }

    // GET: api/JobApplications
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobApplication>>> GetUsersApplications([FromBody] Guid userId)
    {
        var jobApplications = await _jobApplicationService.GetUsersApplications(userId);
        return Ok(jobApplications);
    }

    // GET: api/JobApplications/5
    [HttpGet("{id}")]
    public async Task<ActionResult<JobApplication>> GetJobApplication(Guid id)
    {
        var jobApplication = await _context.JobApplications.FindAsync(id);

        if (jobApplication == null)
        {
            return NotFound();
        }

        return jobApplication;
    }

    // PUT: api/JobApplications/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutJobApplication(Guid id, JobApplication jobApplication)
    {
        if (id != jobApplication.Id)
        {
            return BadRequest();
        }

        _context.Entry(jobApplication).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!JobApplicationExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/JobApplications
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<JobApplication>> PostJobApplication(JobApplication jobApplication)
    {
        _context.JobApplications.Add(jobApplication);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetJobApplication", new { id = jobApplication.Id }, jobApplication);
    }

    // DELETE: api/JobApplications/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJobApplication(int id)
    {
        var jobApplication = await _context.JobApplications.FindAsync(id);
        if (jobApplication == null)
        {
            return NotFound();
        }

        _context.JobApplications.Remove(jobApplication);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool JobApplicationExists(Guid id)
    {
        return _context.JobApplications.Any(e => e.JobApplicationId == id);
    }
}

