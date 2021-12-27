namespace GameConsole;

public class PlayerCharacter
{
    private readonly SpecialDefence.SpecialDefence _specialDefence;

    public PlayerCharacter(SpecialDefence.SpecialDefence specialDefence)
    {
        _specialDefence = specialDefence
            ?? throw new ArgumentNullException(nameof(specialDefence));
    }
    public string? Name { get; set; }
    
    public int? DaysSinceLastLogin { get; set; }
    
    public DateTime? LoginTime { get; set; }

    private int Health { get; set; } = 100;
    
    public bool? IsNew { get; set; }

    public void Hit(int damage)
    {
        var damageReduction = _specialDefence.CalculateDamageReduction();

        var damageTaken = Math.Abs(damageReduction - damage);
        Health -= damageTaken;

        Console.WriteLine($"{Name} health reduced by {damageTaken} to {Health}");
    }
}