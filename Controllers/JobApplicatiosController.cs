using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApplicationTracker.Data;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobApplicatiosController : ControllerBase
{
    private readonly JobAppTrackerContext _context;

    public JobApplicatiosController(JobAppTrackerContext context)
    {
        _context = context;
    }

    // GET: api/JobApplicatios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobApplication>>> GetJobApplications()
    {
        return await _context.JobApplications.ToListAsync();
    }

    // GET: api/JobApplicatios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<JobApplication>> GetJobApplication(int id)
    {
        var jobApplication = await _context.JobApplications.FindAsync(id);

        if (jobApplication == null)
        {
            return NotFound();
        }

        return jobApplication;
    }

    // PUT: api/JobApplicatios/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutJobApplication(int id, JobApplication jobApplication)
    {
        if (id != jobApplication.JobApplicationId)
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

    // POST: api/JobApplicatios
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<JobApplication>> PostJobApplication(JobApplication jobApplication)
    {
        _context.JobApplications.Add(jobApplication);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetJobApplication", new { id = jobApplication.JobApplicationId }, jobApplication);
    }

    // DELETE: api/JobApplicatios/5
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

    private bool JobApplicationExists(int id)
    {
        return _context.JobApplications.Any(e => e.JobApplicationId == id);
    }
}

