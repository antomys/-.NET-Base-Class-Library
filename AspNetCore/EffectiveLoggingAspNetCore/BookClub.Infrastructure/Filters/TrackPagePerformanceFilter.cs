using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BookClub.Infrastructure.Filters;

public class TrackPagePerformanceFilter : IPageFilter
{
    private readonly ILogger<TrackPagePerformanceFilter> _logger;
    private readonly Stopwatch _stopwatch = new();
    public TrackPagePerformanceFilter(ILogger<TrackPagePerformanceFilter> logger)
    {
        _logger = logger;
    }
    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
        // dummy
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        _stopwatch.Start();
    }

    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
        if (context.Exception is not null)
        {
            _stopwatch.Stop();

            _logger.LogPageModelPerformance(context.ActionDescriptor.RelativePath,
                context.HttpContext.Request.Method,
                _stopwatch.ElapsedMilliseconds.ToString());
        }
        
        _stopwatch.Reset();
    }
}