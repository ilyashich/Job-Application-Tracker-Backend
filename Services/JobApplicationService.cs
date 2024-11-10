using JobApplicationTracker.Models;
using JobApplicationTracker.Repositories.Interfaces;
using JobApplicationTracker.Services.Interfaces;

namespace JobApplicationTracker.Services;

public class JobApplicationService : IJobApplicationService
{
    private readonly IJobApplicationRepository _jobRepository;

    public JobApplicationService(IJobApplicationRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<IEnumerable<JobApplication>> GetUsersApplications(Guid userId)
    {
        return await _jobRepository.GetUsersApplications(userId);
    }

    public async Task<JobApplication?> GetById(Guid id)
    {
        return await _jobRepository.GetById(id);
    }

    public async Task<Guid> CreateJobApplication(JobApplication jobApplication)
    {
        return await _jobRepository.CreateJobApplication(jobApplication);
    }

    public async Task<Guid> UpdateJobApplication(JobApplication jobApplication)
    {
        return await _jobRepository.UpdateJobApplication(jobApplication);
    }

    public async Task<Guid> DeleteJobApplication(JobApplication jobApplication)
    {
        return await _jobRepository.DeleteJobApplication(jobApplication);
    }
}