using System;
using System.IO;

namespace Monitoring_the_File_System_for_Changes
{
    internal static class FileSystemWatcherExtension
    {
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
        }
    }
}