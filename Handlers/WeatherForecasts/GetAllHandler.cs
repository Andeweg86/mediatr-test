using ad.mediatr.test.Exceptions;
using ad.mediatr.test.Queries.WeatherForecasts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ad.mediatr.test.Handlers.WeatherForecasts;

public class GetAllHandler : IRequestHandler<GetAllQuery, IEnumerable<WeatherForecast>> 
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<IEnumerable<WeatherForecast>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }));
    }
}