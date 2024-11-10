using FluentValidation;
using JobApplicationTracker.Models;
using JobApplicationTracker.Validation;
using OneOf;
using FluentValidation.Results;
using JobApplicationTracker.Dtos.Requests;
using JobApplicationTracker.Extensions;
using JobApplicationTracker.Repositories.Interfaces;
using JobApplicationTracker.Services.Interfaces;

namespace JobApplicationTracker.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly IValidator<User> _userValidator;

    public UserService(IUserRepository userRepository, IValidator<User> userValidator, IAuthService authService)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
        _authService = authService;
    }

    public async Task<OneOf<User, ValidationFailed>> Register(RegisterUserRequest registerRequest)
    {
        var user = registerRequest.MapToUser();
        var validationResult = await _userValidator.ValidateAsync(user);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }
        
        var existingUserEmail = await _userRepository.GetByEmail(user.Email);
        var existingUserName = await _userRepository.GetByUsername(user.UserName);
        
        var errors = new List<ValidationFailure>();
        
        if (existingUserEmail != null)
        {
            errors.Add(new ValidationFailure("Email", $"User with email {user.Email} already exists."));
        }

        if (existingUserName != null)
        {
            errors.Add(new ValidationFailure("Username", $"User with username {user.UserName} already exists."));
        }

        if (errors.Count != 0)
        {
            return new ValidationFailed(errors);
        }

        user.PasswordHash = _authService.HashPassword(user.PasswordHash);

        await _userRepository.AddUser(user);
        return user;
    }

    public async  Task<OneOf<string, ValidationFailed>> Login(LoginUserRequest loginRequest)
    {
        var existingUser = await _userRepository.GetByUsername(loginRequest.UserName);

        if (existingUser == null)
        {
            var error = new ValidationFailure("Username", $"User with username {loginRequest.UserName} does not exist.");
            return new ValidationFailed(error);
        }
        
        var isPasswordCorrect = _authService.VerifyPassword(loginRequest.Password, existingUser.PasswordHash);

        if (!isPasswordCorrect)
        {
            var error = new ValidationFailure("Login", "Wrong username or password.");
            return new ValidationFailed(error);
        }

        var token = _authService.GenerateToken(existingUser);

        return token;
    }
}