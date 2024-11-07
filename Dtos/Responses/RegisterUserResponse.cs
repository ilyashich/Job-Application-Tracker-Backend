namespace JobApplicationTracker.Dtos.Responses;

public class RegisterUserResponse
{
    public required Guid UserId { get; init; }
    public required string UserName { get; init; }
    public required string Email { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}