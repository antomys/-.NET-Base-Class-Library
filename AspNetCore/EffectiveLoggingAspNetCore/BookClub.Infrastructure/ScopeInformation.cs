using System.Reflection;

namespace BookClub.Infrastructure;

public class ScopeInformation : IScoreInformation
{
    public ScopeInformation()
    {
        HostScopeInfo = new Dictionary<string, string>()
        {
            {"MachineName", Environment.MachineName},
            {"EntryPoint", Assembly.GetEntryAssembly()?.GetName().Name!}
        };
    }

    public IDictionary<string, string> HostScopeInfo { get; }
}