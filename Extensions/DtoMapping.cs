using JobApplicationTracker.Dtos.Requests;
using JobApplicationTracker.Dtos.Responses;
using JobApplicationTracker.Models;
using JobApplicationTracker.Validation;

namespace JobApplicationTracker.Extensions;

public static class DtoMapping
{
    public static User MapToUser(this RegisterUserRequest request)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            Email = request.Email,
            PasswordHash = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName
        };
    }
    
    public static RegisterUserResponse MapToResponse(this User user)
    {
        return new RegisterUserResponse
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
    
    
    public static ValidationFailureResponse MapToResponse(this ValidationFailed failed)
    {
        return new ValidationFailureResponse
        {
            Errors = failed.Errors.Select(x => new ValidationResponse
            {
                PropertyName = x.PropertyName,
                Message = x.ErrorMessage
            })
        };
    }
    
}