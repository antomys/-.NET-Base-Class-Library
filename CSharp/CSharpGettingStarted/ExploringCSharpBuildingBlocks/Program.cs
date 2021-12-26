namespace ExploringCSharpBuildingBlocks;

internal static class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello world!");
        Console.WriteLine(ToFahrenheit(-5));
    }

    private static float ToFahrenheit(float celsius) => (celsius - 32) / 1.8f;
} 