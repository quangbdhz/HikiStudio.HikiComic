using FluentValidation;
using HikiComic.ViewModels.Users.UserDataRequest;

namespace HikiComic.ViewModels.Users.UserRequestValidator
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator() 
        {

            RuleFor(x => x.Password)
               .MinimumLength(6).WithMessage("Password must be from 6 to 32 characters.")
               .MaximumLength(32).WithMessage("Password must be from 6 to 32 characters.");

            RuleFor(x => x.ConfirmPassword)
               .MinimumLength(6).WithMessage("ConfirmPassword must be from 6 to 32 characters.")
               .MaximumLength(32).WithMessage("ConfirmPassword must be from 6 to 32 characters.");

            RuleFor(x => x.Email)
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match.");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("ConfirmPassword is not match.");
                }
            });
        }
    }
}
