using System;
using System.IO;
using System.Runtime.Caching;

namespace Reading_and_Writing_CSV_Data
{
    internal static class FileSystemWatcherExtension
    {
        // Implementing bag to eliminate processing duplicates
        private static readonly MemoryCache MemoryCache = MemoryCache.Default;
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
            e.FullPath.Process();
        }

        internal static void FileSystemWatcherOnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now}]: Deleted file {e.Name} in {e.FullPath}");
        }

        internal static void FileSystemWatcherOnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now}]: Created file {e.Name} in {e.FullPath}");
            AddToCache(e.FullPath);
        }

        private static void Process(this string fullPath)
        {
            var fileName = Path.GetFileName(fullPath);
            
            if (File.GetAttributes(fullPath).HasFlag(FileAttributes.Directory))
                return;
            
            if (string.IsNullOrEmpty(fullPath))
                throw new ArgumentNullException(fullPath);
            
            if (MemoryCache.Contains(fileName)) return;
            
            var processFile = new FileProcessor(fullPath);
            processFile.ProcessFile().ConfigureAwait(false);
        }

        internal static void FileSystemWatcherOnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now}]: Changed file {e.Name}");
            AddToCache(e.FullPath);
        }

        private static void AddToCache(this string fullPath)
        {
            var newItem = new CacheItem(Path.GetFileNameWithoutExtension(fullPath), fullPath);
            var cachingPolicy = new CacheItemPolicy
            {
                RemovedCallback = ProcessFile,
                SlidingExpiration = TimeSpan.FromSeconds(2)
            };
            MemoryCache.Add(newItem,cachingPolicy);
        }

        private static void ProcessFile(CacheEntryRemovedArguments removedArguments)
        {
            Console.WriteLine($"[{DateTime.Now}]: Removed item {removedArguments.CacheItem}. Reason: {removedArguments.RemovedReason}");

            if (removedArguments.RemovedReason == CacheEntryRemovedReason.Expired)
            {
                var processor = new FileProcessor(removedArguments.CacheItem.Value.ToString());
                processor.ProcessFile().ConfigureAwait(false);
            }
            else
            {
                Console.WriteLine($"Unexpected reason removal: {removedArguments.CacheItem.Key}");
            }
        }
    }
}