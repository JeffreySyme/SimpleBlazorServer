using AutoMapper;

namespace SimpleBlazorServer.Queries.WeatherForecast
{
    public partial class GetWeatherForecast
    {
        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<WeatherForecast, WeatherForecastResponse>();
            }
        }
    }
}
