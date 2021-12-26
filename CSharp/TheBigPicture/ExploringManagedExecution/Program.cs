namespace ExploringManagedExecution;

internal static class Program
{
    public static void Main()
    {
        Console.WriteLine("Main called. Enter to call next");
        Console.ReadLine();
        
        var sum = Add(30,12);

        Console.WriteLine(sum);
        Console.WriteLine("Enter to exit.");
        Console.ReadLine();
    }
    private static int Add(int a, int b) => a+b;
}