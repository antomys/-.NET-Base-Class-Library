namespace GameConsole;

public class PlayerCharacter
{
    public string? Name { get; set; }
    
    public int? DaysSinceLastLogin { get; set; }
    
    public DateTime? LoginTime { get; set; }
    
    public bool? IsNew { get; set; }
}