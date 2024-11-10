using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Models;

public class User
{
    [Key]
    public required Guid Id { get; init; } = Guid.NewGuid();
    
    [MaxLength(64)]
    public required string UserName { get; init; }
    
    [MaxLength(64)]
    public required string Email { get; init; }
    
    [MaxLength(256)]
    public required string PasswordHash { get; set; }
    
    [MaxLength(32)]
    public required string FirstName { get; init; }
    
    [MaxLength(32)]
    public required string LastName { get; init; }
    
    public virtual ICollection<JobApplication> JobApplications { get; init; } = new List<JobApplication>();
}