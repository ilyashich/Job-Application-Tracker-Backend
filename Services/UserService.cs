using FluentValidation;
using JobApplicationTracker.Models;
using JobApplicationTracker.Repositories;
using JobApplicationTracker.Validation;
using OneOf;
using FluentValidation.Results;

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

    public async Task<OneOf<User, ValidationFailed>> Register(User user)
    {
        var validationResult = await _userValidator.ValidateAsync(user);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }
        
        var existingUser = await _userRepository.GetByEmail(user.Email);
        if (existingUser != null)
        {
            var error = new ValidationFailure("Email", $"User with email {user.Email} already exists.");
            return new ValidationFailed(error);
        }

        user.HashedPassword = _authService.HashPassword(user.HashedPassword);

        await _userRepository.AddUser(user);
        return user;
    }
}