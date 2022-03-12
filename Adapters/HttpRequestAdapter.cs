using System.Net;
using ad.mediatr.test.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ad.mediatr.test.Adapters;

public enum SuccessResponseType
{
    Ok,
    OkObject,
    Created
}

public interface IHttpRequestAdapter
{
    Task<IActionResult> Handle<TRequest>(TRequest request, SuccessResponseType successResponseType);
}

public class HttpRequestAdapter : IHttpRequestAdapter
{
    private readonly IMediator _mediator;
    public HttpRequestAdapter(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<IActionResult> Handle<TRequest>(TRequest request, SuccessResponseType successResponseType = SuccessResponseType.Ok)
    {
        try
        {
            var result = await _mediator.Send(request!);

            switch (successResponseType)
            {
                case SuccessResponseType.Ok:
                    return new OkResult();
                case SuccessResponseType.OkObject:
                    return new OkObjectResult(result);
                case SuccessResponseType.Created:
                    return new CreatedResult(string.Empty, result);
            }

            return new OkObjectResult(result);
        }
        catch (NotFoundException)
        {
            return new NotFoundResult();
        }
        catch (ValidationException)
        {
            return new BadRequestResult();
        }
    }
}