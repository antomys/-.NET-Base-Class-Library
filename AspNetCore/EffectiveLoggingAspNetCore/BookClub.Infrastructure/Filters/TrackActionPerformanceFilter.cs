using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BookClub.Infrastructure.Filters;
 
public class TrackActionPerformanceFilter : IActionFilter
{
    private readonly ILogger<TrackActionPerformanceFilter> _logger;
    private readonly Stopwatch _stopwatch = new();
    private IDisposable _scopeInformation = null!;
    
    public TrackActionPerformanceFilter(ILogger<TrackActionPerformanceFilter> logger)
    {
        _logger = logger;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch.Start();
        
        var dictionary = new Dictionary<string, string>
        {
            {"MachineName", Environment.MachineName},
            {"EntryPoint", Assembly.GetEntryAssembly()?.GetName().Name!}
        };
        _scopeInformation = _logger.BeginScope(dictionary);
    }

    public void OnActionExecuted(ActionExecutedContext context)
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
        _scopeInformation.Dispose();
    }
}