using FluentValidation.Results;
using JobApplicationTracker.Contracts;
using JobApplicationTracker.Contracts.Requests;
using JobApplicationTracker.Errors;
using JobApplicationTracker.Models;
using JobApplicationTracker.Repositories.Interfaces;
using JobApplicationTracker.Services.Interfaces;
using JobApplicationTracker.Validation;
using OneOf;

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
        return await _jobRepository.GetJobApplicationById(id);
    }

    public async Task<Guid> CreateJobApplication(Guid userId, CreateJobApplicationRequest request)
    {
        var jobApplication = request.MapToJobApplication(userId);
        return await _jobRepository.CreateJobApplication(jobApplication);
    }

    public async Task<Guid> UpdateJobApplication(JobApplication jobApplication, Guid userId)
    {
        return await _jobRepository.UpdateJobApplication(jobApplication);
    }

    public async Task<OneOf<Guid, JobApplicationDoesNotExistError, AuthorizationEditError>> DeleteJobApplication(Guid jobApplicationId, Guid userId)
    {
        var jobApplication = await _jobRepository.GetJobApplicationById(jobApplicationId);

        if (jobApplication == null)
        {
            return new JobApplicationDoesNotExistError(jobApplicationId);
        }

        if (jobApplication.UserId != userId)
        {
            return new AuthorizationEditError();
        }

        return await _jobRepository.DeleteJobApplication(jobApplicationId);
    }
}