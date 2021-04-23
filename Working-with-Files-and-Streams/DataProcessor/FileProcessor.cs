using System;
using System.IO;

namespace DataProcessor
{
    internal class FileProcessor
    {
        private string InternalFileName { get;}
        
        private string InternalDirectoryName { get;}
        public FileProcessor(string internalFileName, string internalDirectoryName = null)
        {
            InternalDirectoryName = internalDirectoryName;
            InternalFileName = internalFileName;
        }
        public void ProcessFile()
        {
            Console.WriteLine($"Beginning processing file {InternalFileName}"!);
        }
        public void ProcessDirectory()
        {
            Console.WriteLine($"Beginning processing file {InternalDirectoryName} with types {InternalFileName}!");
        }
    }
}