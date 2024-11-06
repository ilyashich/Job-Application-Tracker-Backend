using JobApplicationTracker.Dtos;
using JobApplicationTracker.Dtos.Requests;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Extensions;

public static class DtoMapping
{
    public static User MapToUser(this RegisterUserRequest request)
    {
        return new User
        {
            UserId = Guid.NewGuid(),
            UserName = request.UserName,
            Email = request.Email,
            HashedPassword = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };
    }
}