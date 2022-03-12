using ad.mediatr.test.Queries.WeatherForecasts;
using FluentValidation;

namespace ad.mediatr.test.Validators.WeatherForecasts;

public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
{
    public GetByIdQueryValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Test).NotEmpty();
    }
}