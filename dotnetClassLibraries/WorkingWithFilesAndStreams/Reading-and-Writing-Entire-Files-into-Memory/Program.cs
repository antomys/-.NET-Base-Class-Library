using System;
using System.IO;

namespace Reading_and_Writing_Entire_Files_into_Memory
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if(args.Length == 0)
                return;
            args[0].Init();
        }
        
        private static void Init(this string directoryName)
        {
            if (!Directory.Exists(directoryName))
                throw new ArgumentNullException(directoryName);
            using var fileSystemWatcher = new FileSystemWatcher(directoryName)
            {
                IncludeSubdirectories = false, 
                Filter = "*.*",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                // Without this it will not generate events. By default - false.
                EnableRaisingEvents = true
            };

            fileSystemWatcher.InitializeMethods();
            
            Console.WriteLine("Beginning to watch\nPress any key to exit.");
            Console.ReadKey();
        }

        private static void InitializeMethods(this FileSystemWatcher fileSystemWatcher)
        {
            fileSystemWatcher.Created += FileSystemWatcherExtension.FileSystemWatcherOnCreated;
            fileSystemWatcher.Deleted += FileSystemWatcherExtension.FileSystemWatcherOnDeleted;
            fileSystemWatcher.Renamed += FileSystemWatcherExtension.FileSystemWatcherOnRenamed;
            fileSystemWatcher.Error += FileSystemWatcherExtension.FileSystemWatcherOnError;
            fileSystemWatcher.Disposed += FileSystemWatcherExtension.FileSystemWatcherOnDisposed;
            fileSystemWatcher.Changed += FileSystemWatcherExtension.FileSystemWatcherOnChanged;
        }
    }
}
