namespace AssemblingCSharpProgram;

internal static class Program
{
    public static void Main()
    {
        var fahrenheit = WeatherUtilities.celsiusToFahrenheit(12.2f);

        Console.WriteLine(fahrenheit);
    }
}