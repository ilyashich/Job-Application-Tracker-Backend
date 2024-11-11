using JobApplicationTracker.Contracts.Requests;
using JobApplicationTracker.Errors;
using JobApplicationTracker.Models;
using JobApplicationTracker.Validation;
using OneOf;

namespace JobApplicationTracker.Services.Interfaces;

public interface IUserService
{
    Task<OneOf<User, ValidationFailed, Error>> Register(RegisterUserRequest registerRequest);
    Task<OneOf<string, ValidationFailed, Error>> Login(LoginUserRequest loginRequest);
}