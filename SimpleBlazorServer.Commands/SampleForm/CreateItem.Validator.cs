using FluentValidation;
using FluentValidation.Validators;

namespace SimpleBlazorServer.Commands.SampleForm
{
    public partial class CreateItem
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Email is required.")
                    .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                    .WithMessage("Email address is invalid.");

                RuleFor(x => x.Password)
                    .NotEmpty()
                    .WithMessage("Password is required.")
                    .MinimumLength(6)
                    .WithMessage("Password must be at least 6 characters.")
                    .Matches("[A-Z]")
                    .WithMessage("Password must contain at least one capital letter.")
                    .Matches("[a-z]")
                    .WithMessage("Password must contain at least one lower case letter.")
                    .Matches("[0-9]")
                    .WithMessage("Password must contain at least one number.")
                    .Matches("[!@#$%^&*(),.?\":{}|<>]")
                    .WithMessage("Password must contain at least one special character.");

                RuleFor(x => x.ConfirmPassword)
                    .NotEmpty()
                    .WithMessage("Confirm password is required.")
                    .Must(MatchPassword)
                    .WithMessage("The passwords do not match.");
            }

            private bool MatchPassword(Command command, string confirmPassword)
            {
                return command.Password == confirmPassword;
            }
        }
    }
}