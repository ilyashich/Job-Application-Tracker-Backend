using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Models;

public class JobApplication
{
    [Key]
    public int JobApplicationId { get; set; }
    
    [MaxLength(64)]
    public required string JobTitle { get; set; }
    
    [MaxLength(64)]
    public required string CompanyName { get; set; }
    
    public required JobApplicationStatus JobApplicationStatus { get; set; }
    
    public required DateOnly ApplicationDate { get; set; } 
    
    [MaxLength(256)]
    public required string JobPostingUrl { get; set; }
    
    [MaxLength(256)]
    public string? Notes { get; set; }

    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
}