namespace GameConsole;

internal static class PlayerDisplay
{
    internal static void Write(PlayerCharacter playerCharacter)
    {
        Console.WriteLine(
            string.IsNullOrWhiteSpace(playerCharacter.Name) 
                ? "No nickname"
                : playerCharacter.Name);

        Console.WriteLine(
            playerCharacter.DaysSinceLastLogin.HasValue
                ? playerCharacter.DaysSinceLastLogin.Value.ToString()
                : "No DaysSinceLastLogin");

        Console.WriteLine(
            playerCharacter.LoginTime.HasValue 
                ? playerCharacter.LoginTime.Value.ToString("F") 
                : "No login Date");

        Console.WriteLine(playerCharacter.IsNew.HasValue 
            ? $"Player is experienced {playerCharacter.IsNew}" 
            : "Unknown player");
    }
}