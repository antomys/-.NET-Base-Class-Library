namespace BookClub.Infrastructure;

public interface IScoreInformation
{
    IDictionary<string,string> HostScopeInfo { get; }
}