using JobApplicationTracker.Models;

namespace JobApplicationTracker.Repositories.Interfaces;

public interface IJobApplicationRepository
{
    Task<IEnumerable<JobApplication>> GetUsersApplications(Guid userId);
    Task<JobApplication?> GetById(Guid id);
    Task<Guid> CreateJobApplication(JobApplication jobApplication);
    Task<Guid> UpdateJobApplication(JobApplication jobApplication);
    Task<Guid> DeleteJobApplication(JobApplication jobApplication);
}