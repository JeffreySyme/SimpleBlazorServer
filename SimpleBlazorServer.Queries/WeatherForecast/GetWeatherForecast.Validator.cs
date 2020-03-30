using FluentValidation;

namespace SimpleBlazorServer.Queries.WeatherForecast
{
    public partial class GetWeatherForecast
    {
        public class Validator : BaseValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.WeatherForecastId)
                    .GreaterThan(0)
                    .WithMessage("This field must be greater than 0.");
            }
        }
    }
}
