using System;
using System.Collections.Generic;
using System.IO;

namespace Monitoring_the_File_System_for_Changes
{
    internal class FileProcessor
    {
        private string InternalFileName { get;}

        private const string BackUpDirectory = "backup";
        private const string InProcessDirectory = "process";
        private const string CompleteDirectory = "complete";
        
        private string InternalDirectoryName { get;}
        public FileProcessor(string internalFileName, string internalDirectoryName = null)
        {
            InternalDirectoryName = internalDirectoryName;
            InternalFileName = internalFileName ?? throw new ArgumentNullException(nameof(internalFileName));
        }
        public void ProcessFile()
        {
            //Getting root directory
            var rootDirectory = new DirectoryInfo(InternalFileName).Parent?.FullName;
            Console.WriteLine($"Root directory: {rootDirectory}");
            
            //Checking if backUp directory exists
            //If not - creating one
            var path = Path.GetDirectoryName(InternalFileName) ?? string.Empty;
            var backUpPath = Path.Combine(path, BackUpDirectory);
            if (!Directory.Exists(backUpPath))
            {
                Console.WriteLine($"Creating directory: {backUpPath}");
                Directory.CreateDirectory(backUpPath);
            }
            
            // Copying file
            var fileName = Path.GetFileName(InternalFileName) ?? throw new ArgumentNullException(nameof(InternalFileName));
            var backupFilePath = Path.Combine(backUpPath, fileName);

            Console.WriteLine($"Copying {fileName} to {backupFilePath}");
            File.Copy(InternalFileName,backupFilePath, true);
            
            // Moving to Processing directory
            var processDirectory = Path.Combine(path, InProcessDirectory);

            if (!Directory.Exists(processDirectory))
                Directory.CreateDirectory(processDirectory);
            
            processDirectory = Path.Combine(processDirectory, fileName);

            if (File.Exists(backupFilePath) && !File.Exists(processDirectory))
            {
                Console.WriteLine($"Moving file {fileName} from {backupFilePath} to {processDirectory}");
                File.Move(backupFilePath,processDirectory);
            }
            
            //Getting file extension 
            var fileExtension = Path.GetExtension(InternalFileName);
            Console.WriteLine($"Text file extension: {fileExtension}");

            switch (fileExtension)
            {
                case ".txt":
                    Console.WriteLine("Processing file");
                    break;
                default: Console.WriteLine("UNSUPPORTED FILE!");
                    break;
            }
            
            //Adding to completed folder:
            var completedDirectory = Path.Combine(path, CompleteDirectory);
            if (!Directory.Exists(completedDirectory))
                Directory.CreateDirectory(completedDirectory);
            
            completedDirectory = Path.Combine(completedDirectory, fileName);
            
            if (File.Exists(processDirectory) && !File.Exists(completedDirectory))
            {
                Console.WriteLine($"Moving file {fileName} from {InProcessDirectory} to {CompleteDirectory}");
                File.Move(processDirectory, completedDirectory);
            }
            
            Console.WriteLine($"File: {InternalFileName} exists, yay!");
            Console.WriteLine($"Beginning processing file {InternalFileName}"!);
        }
        public void ProcessDirectory()
        {
            Console.WriteLine($"Beginning processing file {InternalDirectoryName} with types {InternalFileName}!");
            var files = InternalFileName.ToLower() switch
            {
                "text" => Directory.GetFiles(InternalDirectoryName, "*.txt"),
                _ => Directory.GetFiles(InternalDirectoryName)
            };
            Console.WriteLine("Found files: ");
            PrintArray(files);
        }

        private static void PrintArray(IEnumerable<string> array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}