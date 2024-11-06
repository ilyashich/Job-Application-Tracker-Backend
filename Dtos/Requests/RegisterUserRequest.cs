using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Dtos.Requests;

public record RegisterUserRequest
(
    [Required] 
    string UserName, 
    [Required]
    string Email, 
    [Required]
    string Password, 
    [Required]
    string FirstName, 
    [Required]
    string LastName
);