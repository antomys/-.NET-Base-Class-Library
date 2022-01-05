using Microsoft.Extensions.Logging;

namespace BookClub.Infrastructure;

public static class LogMessages
{
    private static readonly Action<ILogger, string, string, string, Exception> PageModelPerformance;

    static LogMessages()
    {
        PageModelPerformance = LoggerMessage.Define<string, string, string>
            (LogLevel.Information, 0, "{PageName} {Method} model took {Ms}");
    }

    public static void LogPageModelPerformance(
        this ILogger logger,
        string pageName,
        string methodName,
        string elapsedTime)
    {
        PageModelPerformance(logger, pageName, methodName, elapsedTime, default!);
    }
}