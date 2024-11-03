using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JobApplicationTracker.Models;

public class User : IdentityUser<Guid>
{
    [MaxLength(40)]
    public string? FirstName { get; set; }
    
    [MaxLength(40)]
    public string? LastName { get; set; }
    
    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    
}