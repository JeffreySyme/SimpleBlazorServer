using MediatR;

namespace SimpleBlazorServer.Queries.WeatherForecast
{
    public partial class GetWeatherForecast
    {
        public class Query : BaseQuery, IRequest<Response>
        {
            public int? WeatherForecastId { get; set; }
        }
    }
}
