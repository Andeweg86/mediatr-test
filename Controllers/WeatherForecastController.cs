using ad.mediatr.test.Adapters;
using ad.mediatr.test.Queries.WeatherForecasts;
using Microsoft.AspNetCore.Mvc;

namespace ad.mediatr.test.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IHttpRequestAdapter _adapter;

    public WeatherForecastController(IHttpRequestAdapter adapter)
    {
        _adapter = adapter;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => await _adapter.Handle(new GetByIdQuery(id), SuccessResponseType.OkObject);
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => await _adapter.Handle(new GetAllQuery(), SuccessResponseType.OkObject);
}