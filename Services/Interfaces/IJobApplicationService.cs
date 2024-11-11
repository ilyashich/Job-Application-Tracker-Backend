using JobApplicationTracker.Contracts.Requests;
using JobApplicationTracker.Errors;
using JobApplicationTracker.Models;
using JobApplicationTracker.Validation;
using OneOf;

namespace JobApplicationTracker.Services.Interfaces;

public interface IJobApplicationService
{
    Task<IEnumerable<JobApplication>> GetUsersApplications(Guid userId);
    Task<JobApplication?> GetById(Guid id);
    Task<Guid> CreateJobApplication(Guid userId, CreateJobApplicationRequest request);
    Task<Guid> UpdateJobApplication(JobApplication jobApplication, Guid userId);
    Task<OneOf<Guid, JobApplicationDoesNotExistError, AuthorizationEditError>> DeleteJobApplication(Guid jobApplicationId, Guid userId);
}