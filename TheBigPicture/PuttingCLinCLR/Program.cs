namespace PuttingCLinCLR;

internal static class Program
{
    public static void Main()
    {
        const int a = 30;
        const int b = 12;
        var sum = FSharpLibrary.Calculator.Add(a, b);
        Console.WriteLine(sum);
    }
}