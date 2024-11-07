using JobApplicationTracker.Dtos.Requests;
using JobApplicationTracker.Models;
using JobApplicationTracker.Validation;
using OneOf;

namespace JobApplicationTracker.Services.Interfaces;

public interface IUserService
{
    Task<OneOf<User, ValidationFailed>> Register(RegisterUserRequest registerRequest);
    Task<OneOf<string, ValidationFailed>> Login(LoginUserRequest loginRequest);
}