using FluentValidation;
using JobApplicationTracker.Models;
using JobApplicationTracker.Validation;
using OneOf;
using JobApplicationTracker.Contracts;
using JobApplicationTracker.Contracts.Requests;
using JobApplicationTracker.Errors;
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

    public async Task<OneOf<User, ValidationFailed, Error>> Register(RegisterUserRequest registerRequest)
    {
        var user = registerRequest.MapToUser();
        var validationResult = await _userValidator.ValidateAsync(user);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }
        
        var existingUserEmail = await _userRepository.GetByEmail(user.Email);
        var existingUserName = await _userRepository.GetByUsername(user.UserName);
        
        //var errors = new List<ValidationFailure>();
        
        if (existingUserEmail != null)
        {
            return new EmailAlreadyExistsError(user.Email);
        }

        if (existingUserName != null)
        {
            return new UsernameAlreadyExistsError(user.UserName);
        }

        user.PasswordHash = _authService.HashPassword(user.PasswordHash);

        await _userRepository.AddUser(user);
        return user;
    }

    public async  Task<OneOf<string, ValidationFailed, Error>> Login(LoginUserRequest loginRequest)
    {
        var existingUser = await _userRepository.GetByUsername(loginRequest.UserName);

        if (existingUser == null)
        {
            return new UsernameDoesNotExistError(loginRequest.UserName);
        }
        
        var isPasswordCorrect = _authService.VerifyPassword(loginRequest.Password, existingUser.PasswordHash);

        if (!isPasswordCorrect)
        {
            return new WrongUserNameOrPasswordError();
        }

        var token = _authService.GenerateToken(existingUser);

        return token;
    }
}