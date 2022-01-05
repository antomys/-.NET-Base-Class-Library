using BookClub.API.ExceptionMiddleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BookClub.Infrastructure.ExceptionMiddleware;

public class ApiExceptionOptions
{
    public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; } = default!;
    
    public Func<Exception, LogLevel> DetermineLogLevel { get; set; } = default!;
}