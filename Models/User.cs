using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Models;

public class User
{
    [Key]
    public Guid UserId { get; set; } = Guid.NewGuid();
    
    [MaxLength(64)]
    public required string UserName { get; set; }
    
    [MaxLength(64)]
    public required string Email { get; set; }
    
    [MaxLength(256)]
    public required string HashedPassword { get; set; }
    
    [MaxLength(32)]
    public required string FirstName { get; set; }
    
    [MaxLength(32)]
    public required string LastName { get; set; }
    
    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
}