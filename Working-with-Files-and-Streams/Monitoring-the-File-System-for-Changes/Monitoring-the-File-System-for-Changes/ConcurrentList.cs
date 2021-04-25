using System.Collections.Generic;

namespace Monitoring_the_File_System_for_Changes
{
    public class ConcurrentList<T>
    {
        private readonly IList<T> _list = new List<T>();
        private readonly object _lock = new();

        public void Add(T item)
        {
            lock (_lock)
            {
                _list.Add(item);
            }
        }

        public void Remove(T item)
        {
            lock (_lock)
            {
                _list.Remove(item);
            }
        }

        public bool Contains(T item)
        {
            lock (_lock)
            {
                return _list.Contains(item);
            }
        }
    }
}