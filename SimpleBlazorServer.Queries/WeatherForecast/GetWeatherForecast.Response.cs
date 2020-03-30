using System;

namespace SimpleBlazorServer.Queries.WeatherForecast
{
    public partial class GetWeatherForecast
    {
        public class Response : BaseResponse<WeatherForecastResponse>
        {
        }
        public class WeatherForecastResponse
        {
            public int WeatherForecastId { get; set; }
            public DateTime Date { get; set; }
            public int TemperatureC { get; set; }
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
            public string Summary { get; set; }
        }

        public class WeatherForecast
        {
            public int WeatherForecastId { get; set; }
            public DateTime Date { get; set; }
            public int TemperatureC { get; set; }
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
            public string Summary { get; set; }
        }
    }
}
