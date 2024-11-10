using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Models;

public class JobApplication
{
    [Key]
    public required Guid Id { get; init; } = Guid.NewGuid();
    
    [MaxLength(64)]
    public required string JobTitle { get; init; }
    
    [MaxLength(64)]
    public required string CompanyName { get; init; }
    
    public required JobApplicationStatus JobApplicationStatus { get; init; }
    
    public required DateOnly ApplicationDate { get; init; } 
    
    [MaxLength(256)]
    public required string JobPostingUrl { get; init; }
    
    [MaxLength(256)]
    public string? Notes { get; init; }

    public required Guid UserId { get; init; }
    public virtual User? User { get; init; }
}