using BookClub.API.ExceptionMiddleware;
using Microsoft.AspNetCore.Builder;

namespace BookClub.Infrastructure.ExceptionMiddleware;

public static class ApiExceptionMiddlewareExtension
{
    public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var options = new ApiExceptionOptions();
        return builder.UseMiddleware<ApiExceptionMiddleware>(options);
    }
    
    public static IApplicationBuilder UseApiExceptionHandler(
        this IApplicationBuilder builder,
        Action<ApiExceptionOptions> configureOptions)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var options = new ApiExceptionOptions();
        configureOptions(options);
        
        return builder.UseMiddleware<ApiExceptionMiddleware>(options);
    }
}