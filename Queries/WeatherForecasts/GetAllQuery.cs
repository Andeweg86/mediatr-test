using MediatR;

namespace ad.mediatr.test.Queries.WeatherForecasts;

public class GetAllQuery : IRequest<IEnumerable<WeatherForecast>>
{
    
}