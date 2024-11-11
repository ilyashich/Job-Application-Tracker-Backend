using JobApplicationTracker.Contracts.Requests;
using JobApplicationTracker.Contracts.Responses;
using JobApplicationTracker.Models;
using JobApplicationTracker.Validation;

namespace JobApplicationTracker.Contracts;

public static class ContractMapping
{
    public static User MapToUser(this RegisterUserRequest request)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            Email = request.Email,
            PasswordHash = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName
        };
    }

    public static JobApplication MapToJobApplication(this CreateJobApplicationRequest request, Guid userId)
    {
        return new JobApplication
        {
            Id = Guid.NewGuid(),
            JobTitle = request.JobTitle,
            CompanyName = request.CompanyName,
            ApplicationDate = request.ApplicationDate,
            JobApplicationStatus = request.JobApplicationStatus,
            JobPostingUrl = request.JobPostingUrl,
            Notes = request.Notes,
            UserId = userId
        };
    }

    public static RegisterUserResponse MapToResponse(this User user)
    {
        return new RegisterUserResponse
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
    
    
    public static ValidationFailureResponse MapToResponse(this ValidationFailed failed)
    {
        return new ValidationFailureResponse
        {
            Errors = failed.Errors.Select(x => new ValidationResponse
            {
                PropertyName = x.PropertyName,
                Message = x.ErrorMessage
            })
        };
    }
    
}