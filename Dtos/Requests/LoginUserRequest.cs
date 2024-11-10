namespace JobApplicationTracker.Dtos.Requests;

public class LoginUserRequest
{
    public required string UserName { get; init; }
    public required string Password { get; init; }
}