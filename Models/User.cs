using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JobApplicationTracker.Models;

public class User
{
    [Key]
    public Guid UserId { get; set; } = Guid.NewGuid();
    [Required]
    [MaxLength(40)] 
    public string Username { get; set; } = default!;
    [Required]
    [MaxLength(256)]
    public string PasswordHash { get; set; } = default!;
    [Required]
    [MaxLength(40)]
    public string Email { get; set; } = default!;
    [Required]
    [MaxLength(40)]
    public string FirstName { get; set; } = default!;
    [Required]
    [MaxLength(40)]
    public string LastName { get; set; } = default!;
    
    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    
}