using JobApplicationTracker.Models;
using JobApplicationTracker.Validation;
using OneOf;


namespace JobApplicationTracker.Services;

public interface IUserService
{
    Task<OneOf<User, ValidationFailed>> Register(User user);
}