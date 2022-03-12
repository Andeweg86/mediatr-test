using ad.mediatr.test.Queries.WeatherForecasts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ad.mediatr.test.Handlers.WeatherForecasts;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, WeatherForecast> 
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<WeatherForecast> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new WeatherForecast
        {
            Date = DateTime.Now.AddDays(Random.Shared.Next(-20, 55)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });
    }
}