using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Reading_and_Writing_Entire_Files_into_Memory
{
    internal class FileProcessor
    {
        private string InternalFileName { get;}

        private const string BackUpDirectory = "backup";
        private const string InProcessDirectory = "process";
        private const string CompleteDirectory = "complete";

        public FileProcessor(string internalFileName, string internalDirectoryName = null)
        {
            InternalFileName = internalFileName ?? throw new ArgumentNullException(nameof(internalFileName));
        }
        public async Task ProcessFile()
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

            var completedDirectory = Path.Combine(path, CompleteDirectory);
            if (!Directory.Exists(completedDirectory))
                Directory.CreateDirectory(completedDirectory);
            completedDirectory = Path.Combine(completedDirectory,  Path.GetFileNameWithoutExtension(fileName) + '-' + Guid.NewGuid() + fileExtension);

            var processor = new TextFileProcessor(processDirectory, completedDirectory);
            switch (fileExtension)
            {
                case ".txt":
                    await processor.ProcessAsStringArrays();
                    break;
                default: await processor.ProcessAsByteArray();
                    break;
            }
            Console.WriteLine($"File: {InternalFileName} exists, yay!");
            Console.WriteLine($"[{DateTime.Now}] Processed file {Path.GetFileName(InternalFileName)}!");
        }
    }
}