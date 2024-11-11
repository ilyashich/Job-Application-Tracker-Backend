using JobApplicationTracker.Models;

namespace JobApplicationTracker.Contracts.Requests;

public class CreateJobApplicationRequest
{
    public required string JobTitle { get; init; }
    public required string CompanyName { get; init; }
    public required JobApplicationStatus JobApplicationStatus { get; init; }
    public required DateOnly ApplicationDate { get; init; } 
    public required string JobPostingUrl { get; init; }
    public string? Notes { get; init; }
}