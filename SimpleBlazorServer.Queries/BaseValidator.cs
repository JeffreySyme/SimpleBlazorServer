using FluentValidation;

namespace SimpleBlazorServer.Queries
{
    public class BaseValidator<T> : AbstractValidator<T> where T : BaseQuery
    {
        public BaseValidator()
        {
            RuleFor(x => x.Skip)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Skip must be greater than or equal to 0.");

            RuleFor(x => x.Take)
                .InclusiveBetween(0, 100000)
                .WithMessage("Take must be between 0 and 100000");
        }
    }
}
