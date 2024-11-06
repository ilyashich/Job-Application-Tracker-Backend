using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Dtos.Requests;

public record LoginUserRequest
(
    [Required] 
    string Email, 
    [Required] 
    string Password
);