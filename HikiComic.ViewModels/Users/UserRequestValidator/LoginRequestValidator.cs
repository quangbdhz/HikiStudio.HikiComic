using FluentValidation;
using HikiComic.ViewModels.Users.UserDataRequest;

namespace HikiComic.ViewModels.Users.UserRequestValidator
{
    public class LoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .NotNull().WithMessage("Email is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .NotNull().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be from 6 to 32 characters")
                .MaximumLength(32).WithMessage("Password must be from 6 to 32 characters");

            RuleFor(x => x.RememberMe)
                .NotNull().WithMessage("RememberMe is required.");
        }
    }
}
