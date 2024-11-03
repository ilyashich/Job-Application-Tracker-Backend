using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JobApplicationTracker.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
}