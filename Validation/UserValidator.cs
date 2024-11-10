using FluentValidation;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Validation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.UserName).Length(3, 50);
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.FirstName).Length(1, 15);
        RuleFor(x => x.LastName).Length(1, 15);
    }
}