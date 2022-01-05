using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BookClub.Infrastructure.Attributes;

public class TrackPerformance : ActionFilterAttribute
{
    private readonly ILogger<TrackPerformance> _logger;
    private readonly Stopwatch _stopwatch = new();

    public TrackPerformance(ILogger<TrackPerformance> logger)
    {
        _logger = logger;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch.Start();
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is null)
        {
            _stopwatch.Stop();
            _logger.LogPageModelPerformance(
                context.HttpContext.Request.Path,
                context.HttpContext.Request.Method, 
                _stopwatch.ElapsedMilliseconds.ToString());
        }
        
        _stopwatch.Reset();
    }
}