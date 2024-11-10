using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using JobApplicationTracker.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Repositories;

public class JobApplicationRepository : IJobApplicationRepository
{
    private readonly JobApplicationContext _db;

    public JobApplicationRepository(JobApplicationContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<JobApplication>> GetUsersApplications(Guid userId)
    {
        return await _db.JobApplications
            .AsNoTracking()
            .Where(application => application.UserId == userId).ToListAsync();
    }

    public async Task<JobApplication?> GetById(Guid id)
    {
        return await _db.JobApplications
            .AsNoTracking()
            .SingleOrDefaultAsync(application => application.Id == id);
    }

    public async Task<Guid> CreateJobApplication(JobApplication jobApplication)
    {
        await _db.JobApplications.AddAsync(jobApplication);
        await _db.SaveChangesAsync();
        return jobApplication.Id;
    }

    public async Task<Guid> UpdateJobApplication(JobApplication jobApplication)
    {
        await _db.JobApplications
            .Where(j => j.Id == jobApplication.Id)
            .ExecuteUpdateAsync(setter => setter
                .SetProperty(j => j.JobTitle, jobApplication.JobTitle)
                .SetProperty(j => j.CompanyName, jobApplication.CompanyName)
                .SetProperty(j => j.ApplicationDate, jobApplication.ApplicationDate)
                .SetProperty(j => j.JobApplicationStatus, jobApplication.JobApplicationStatus)
                .SetProperty(j => j.JobPostingUrl, jobApplication.JobPostingUrl)
                .SetProperty(j => j.Notes, jobApplication.Notes));
        return jobApplication.Id;
    }

    public async Task<Guid> DeleteJobApplication(JobApplication jobApplication)
    {
        await _db.JobApplications
            .Where(j => j.Id == jobApplication.Id)
            .ExecuteDeleteAsync();
        return jobApplication.Id;
    }
}