using FluentValidation;
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
    private readonly IValidator<JobApplication> _jobApplicationValidator;

    public JobApplicationService(IJobApplicationRepository jobRepository, IValidator<JobApplication> jobApplicationValidator)
    {
        _jobRepository = jobRepository;
        _jobApplicationValidator = jobApplicationValidator;
    }

    public async Task<IEnumerable<JobApplication>> GetUsersApplications(Guid userId)
    {
        return await _jobRepository.GetUsersApplications(userId);
    }

    public async Task<JobApplication?> GetById(Guid id)
    {
        return await _jobRepository.GetJobApplicationById(id);
    }

    public async Task<OneOf<Guid, ValidationFailed>> CreateJobApplication(CreateJobApplicationRequest request, Guid userId)
    {
        var jobApplication = request.MapToJobApplication(userId);
        var validationResult = await _jobApplicationValidator.ValidateAsync(jobApplication);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }
        return await _jobRepository.CreateJobApplication(jobApplication);
    }

    public async Task<OneOf<Guid, JobApplicationDoesNotExistError, AuthorizationEditError, ValidationFailed>> UpdateJobApplication(UpdateJobApplicationRequest request, Guid userId)
    {
        var existingJobApplication = await _jobRepository.GetJobApplicationById(request.Id);
        
        if (existingJobApplication == null)
        {
            return new JobApplicationDoesNotExistError(request.Id);
        }
        
        if (existingJobApplication.UserId != userId)
        {
            return new AuthorizationEditError();
        }
        
        var jobApplication = request.MapToJobApplication(userId);
        
        var validationResult = await _jobApplicationValidator.ValidateAsync(jobApplication);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }
        
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