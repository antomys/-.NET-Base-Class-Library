using System.Net.Mime;
using System.Text.Json;
using BookClub.API.ExceptionMiddleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BookClub.Infrastructure.ExceptionMiddleware;

public class ApiExceptionMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    private readonly ILogger<ApiExceptionMiddleware> _logger;
    private readonly ApiExceptionOptions _exceptionOptions;

    public ApiExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ApiExceptionMiddleware> logger, ApiExceptionOptions exceptionOptions)
    {
        _requestDelegate = requestDelegate;
        _logger = logger;
        _exceptionOptions = exceptionOptions;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _requestDelegate(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception, _exceptionOptions);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception exception,
        ApiExceptionOptions exceptionOptions)
    {
        var error = new ApiError
        {
            Id = Guid.NewGuid().ToString(),
            Code = StatusCodes.Status500InternalServerError.ToString(),
            Link = httpContext.TraceIdentifier
        };

        exceptionOptions.AddResponseDetails.Invoke(httpContext, exception, error);

        var innedExceptionMessage = GetInnerExceptionMessage(exception);
        
        _logger.LogError(exception, "Error occured, middleware {InnerExceptionMessage}. Error Id : {ErrorId}",innedExceptionMessage,error.Id);
        
        httpContext.Request.ContentType = MediaTypeNames.Application.Json;
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        return httpContext.Response.WriteAsync(JsonSerializer.Serialize(error));
    }

    private static string GetInnerExceptionMessage(Exception exception)
    {
        while (true)
        {
            if (exception.InnerException is null)
                return exception.Message;
            
            exception = exception.InnerException;
        }
    }
}