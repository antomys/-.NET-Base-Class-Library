using System.Collections.Generic;

namespace Monitoring_the_File_System_for_Changes
{
    public class ConcurrentList<T>
    {
        private readonly IList<T> _list = new List<T>();
        private readonly object _lock = new();

        public int Count
        {
            get 
            {
                lock(_lock)
                    return _list?.Count ?? 0;
            }
        }

        public void TryAdd(T item, out bool result)
        {
            lock (_lock)
            {
                if (!_list.Contains(item))
                {
                    _list.Add(item);
                    result = true;
                    return;
                }

                result = false;

            }
        }

        public void Remove(T item, out bool result)
        {
            result = false;
            lock (_lock)
            {
                if (!_list.Contains(item))
                {
                    result=false;
                    return;
                }
                _list.Remove(item);
                result = true;
            }
        }

        public bool Contains(T item)
        {
            lock (_lock)
            {
                return _list.Contains(item);
            }
        }

        public T this[int i]
        {
            get
            {
                lock(_lock)
                    return _list != null ? _list[i] : default;
            }
        }
    }
}