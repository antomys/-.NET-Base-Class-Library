using Microsoft.AspNetCore.Http;

namespace BookClub.API.ExceptionMiddleware;

public class ApiExceptionOptions
{
    public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; } = default!;
}