using FluentValidation;

namespace SimpleBlazorServer.Commands.Counter
{
    public partial class IncrementCounter
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Value)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("This field must be greater than or equal to 0.");
            }
        }
    }
}
