using System;
using System.Collections.Concurrent;
using System.IO;

namespace Monitoring_the_File_System_for_Changes
{
    internal static class FileSystemWatcherExtension
    {
        // Implementing bag to eliminate processing duplicates
        private static readonly ConcurrentList<string> BagOfFileNames = new ConcurrentList<string>();
        internal static void FileSystemWatcherOnDisposed(object sender, EventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now}]: Disposed {e}");
        }

        internal static void FileSystemWatcherOnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now}]: Occured error {e.GetException().Message}");
        }

        internal static void FileSystemWatcherOnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now}]: Renamed file {e.OldName} to {e.Name}");
        }

        internal static void FileSystemWatcherOnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now}]: Deleted file {e.Name} in {e.FullPath}");
        }

        internal static void FileSystemWatcherOnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now}]: Created file {e.Name} in {e.FullPath}");
            e.FullPath.Process();
        }

        private static void Process(this string fullPath)
        {
            var fileName = Path.GetFileName(fullPath);
            if (string.IsNullOrEmpty(fullPath))
                throw new ArgumentNullException(fullPath);
            if (BagOfFileNames.Contains(fileName)) return;
            BagOfFileNames.Add(fileName);
            var processFile = new FileProcessor(fullPath);
            processFile.ProcessFile();
        }
    }
}