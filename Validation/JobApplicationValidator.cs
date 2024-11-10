using FluentValidation;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Validation;

public class JobApplicationValidator : AbstractValidator<JobApplication>
{
    public JobApplicationValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.JobTitle).NotEmpty();
        RuleFor(x => x.CompanyName).NotEmpty();
        RuleFor(x => x.JobApplicationStatus).IsInEnum();
        RuleFor(x => x.ApplicationDate).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow));
        RuleFor(x => x.JobPostingUrl).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}