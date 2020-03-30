using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBlazorServer.Queries.WeatherForecast
{
    public partial class GetWeatherForecast
    {
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly IMapper _mapper;
            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var forecast = await BuildQueryAsync(request);

                var count = forecast.Count();

                var results = forecast.Skip(request.Skip ?? 0).Take(request.Take ?? 50).ToList();

                await Task.Delay(1500);

                return new Response
                {
                    TotalCount = count,
                    Data = results.Select(f => _mapper.Map<WeatherForecastResponse>(f))
                };
            }

            private async Task<IEnumerable<WeatherForecast>> BuildQueryAsync(Query request) 
            {
                var query = await GetForecastAsync(DateTime.Now);

                if (request.WeatherForecastId.HasValue)
                    query = query.Where(x => x.WeatherForecastId == request.WeatherForecastId);

                return query;
            }

            private Task<IEnumerable<WeatherForecast>> GetForecastAsync(DateTime startDate)
            {
                var rng = new Random();
                return Task.FromResult(Enumerable.Range(1, 100).Select(index => new WeatherForecast
                {
                    WeatherForecastId = index,
                    Date = startDate.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).AsEnumerable());
            }

            private static readonly string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
        }
    }
}
