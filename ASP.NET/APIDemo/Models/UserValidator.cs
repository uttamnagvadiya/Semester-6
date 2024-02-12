using FluentValidation;

namespace APIDemo.Models
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username)
                .NotNull().WithMessage("Username is required.")
                .NotEmpty().WithMessage("Username can't be empty.");

            RuleFor(u => u.Password)
                .NotNull().WithMessage("Password is required.")
                .NotEmpty().WithMessage("Username can't be empty.");

            RuleFor(u => u.ConfirmPassword)
                .NotNull().WithMessage("Confirm Password is required.")
                .NotEmpty().WithMessage("Confirm Password can't be empty.")
                .Equal(u => u.Password).WithMessage("Password does not match.");

            RuleFor(u => u.Email)
                .NotNull().WithMessage("Email is required.")
                .NotEmpty().WithMessage("Email can't be empty.")
                .EmailAddress().WithMessage("Email does not valid.");
        }

    }
}
