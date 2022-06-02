namespace DmitryKublashviliHabrLinqIntoKeyhole;

public static class MyLinq
{
    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
    
    // foreach is a special operator. Let's unwrap it.
    
    public static IEnumerable<T> MyWhereUnwrap<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        var enumerator = source.GetEnumerator();

        try
        {
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
            }
        }
        finally
        {
            if (enumerator != null)
            {
                enumerator.Dispose();
            }
        }
    }
    
    public static T MyFirst<T>(this IEnumerable<T> source)
    {
        var enumerator = source.GetEnumerator();
        T result;

        try
        {
            enumerator.MoveNext();
            result = enumerator.Current;
        }
        finally
        {
            if (enumerator != null)
            {
                enumerator.Dispose();
            }
        }

        return result;
    }
    
    public static T MyLast<T>(this IEnumerable<T> source)
    {
        var enumerator = source.GetEnumerator();
        T result;

        try
        {
            while (enumerator.MoveNext())
            {
            }
            result = enumerator.Current;
        }
        finally
        {
            if (enumerator != null)
            {
                enumerator.Dispose();
            }
        }

        return result;
    }
}