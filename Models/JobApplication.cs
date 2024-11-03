using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Models;

public class JobApplication
{
    [Key]
    public int JobApplicationId { get; set; }
    [Required]
    [MaxLength(64)]
    public string JobTitle { get; set; } = default!;
    [Required]
    [MaxLength(64)]
    public string CompanyName { get; set; } = default!;
    [Required]
    public JobApplicationStatus JobApplicationStatus { get; set; }
    [Required]
    public DateOnly ApplicationDate { get; set; } 
    [Required]
    [MaxLength(256)]
    public string JobPostingUrl { get; set; } = default!;
    [MaxLength(256)]
    public string? Notes { get; set; }

    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
}