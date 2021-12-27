namespace CSharpNullBasics;

public static class DefaultExample
{
    public static void Example()
    {
        var message = new Message
        {
            From = null,
            Text = "Hey!"
        };
        
        Console.WriteLine(message.From);
        Console.WriteLine(message.Text);
        Console.WriteLine(message.ToUpperForm());

        Console.WriteLine("Press enter to end.");
        Console.ReadKey();
    }
}