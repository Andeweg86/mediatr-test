using MediatR;

namespace ad.mediatr.test.Queries.WeatherForecasts;

public class GetByIdQuery : IRequest<WeatherForecast>
{
    public int Id { get; }
    public string Test { get; }
    
    public GetByIdQuery(int id)
    {
        Id = id;
    }
}