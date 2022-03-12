using System.Diagnostics;
using MediatR;

namespace ad.mediatr.test.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> 
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    
    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }
    
    public async Task<TResponse> Handle(
        TRequest request, 
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        string requestName = typeof(TRequest).Name;
        string uniqueId = Guid.NewGuid().ToString();
        
        try
        {
            _logger.LogInformation($"Begin Request Id:{uniqueId}, request name:{requestName}");
            var timer = new Stopwatch();
            timer.Start();
            var response = await next();
            timer.Stop();
            _logger.LogInformation($"End Request Id:{uniqueId}, request name:{requestName}, total request time:{timer.ElapsedMilliseconds}");
            return response;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Request Id:{uniqueId}, request name:{requestName}, threw exception {e.GetType()}");
            throw;
        }
    }
}