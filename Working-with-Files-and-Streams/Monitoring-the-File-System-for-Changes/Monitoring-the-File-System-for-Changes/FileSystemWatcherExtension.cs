using System;
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
            e.TryFlush();
            Console.WriteLine($"[{DateTime.Now}]: Renamed file {e.OldName} to {e.Name}");
            e.FullPath.Process();
        }

        internal static void FileSystemWatcherOnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now}]: Deleted file {e.Name} in {e.FullPath}");
        }

        internal static void FileSystemWatcherOnCreated(object sender, FileSystemEventArgs e)
        {
            e.TryFlush();
            Console.WriteLine($"[{DateTime.Now}]: Created file {e.Name} in {e.FullPath}");
            e.FullPath.Process();
        }

        private static void Process(this string fullPath)
        {
            var fileName = Path.GetFileName(fullPath);
            
            if (File.GetAttributes(fullPath).HasFlag(FileAttributes.Directory))
                return;
            
            if (string.IsNullOrEmpty(fullPath))
                throw new ArgumentNullException(fullPath);
            
            for(var i =0; i< BagOfFileNames.Count; i++)
                if(fileName.Contains(Path.GetFileNameWithoutExtension(BagOfFileNames[i]) ?? throw new InvalidOperationException()))
                    return;
            if (BagOfFileNames.Contains(fileName)) return;
            
            BagOfFileNames.TryAdd(fileName, out var result);
            if(result is false) return;
           
            var processFile = new FileProcessor(fullPath);
            processFile.ProcessFile();
        }

        internal static void FileSystemWatcherOnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now}]: Changed file {e.Name}");
            e.FullPath.Process();
        }

        private static void TryFlush(this FileSystemEventArgs e)
        {
            if(BagOfFileNames.Contains(e.Name))
                BagOfFileNames.Remove(e.Name, out _);
        }
    }
}