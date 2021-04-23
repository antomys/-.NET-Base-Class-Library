using System;

namespace DataProcessor
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if(args.Length==0)
                return;
            
            switch(args[0])
            {
                case "--file":
                {
                    Console.WriteLine($"Chosen command is {args[0]}, fileName is {args[1]}");
                    ProcessFile(args[1]);
                    break;
                }
                case "--dir":
                {
                    Console.WriteLine($"Chosen command is {args[0]},"
                    + "directory is {args[1]}, fileType is {args[2]}");
                    ProcessDirectory(args[1],args[2]);
                    break;
                }
                default: 
                {
                    Console.WriteLine("Invalid Operation!");
                    break;
                }
            }
            Console.WriteLine("Press any key to exit");
            
            Console.ReadKey();
        }

        private static void ProcessFile(string fileName)
        {
            var processor = new FileProcessor(fileName);
            processor.ProcessFile();
        }

        private static void ProcessDirectory(string directoryName, string fileType)
        {
            var processor = new FileProcessor(fileType,directoryName);
            processor.ProcessDirectory();
        }
    }
}
