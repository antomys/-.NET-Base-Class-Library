using System.Text;

namespace CSharpPerformanceBook.Benchmarks.Extensions;

public static class StringExtensions
{
    public static string BuildBadly(this string value, int count)
    {
        for (var i = 0; i < count; i++)
        {
            value += " " + "test";
        }

        return value;
    }
    
    public static string BuildBetter(this string value, int count)
    {
        var sb = new StringBuilder(value);
        for (var i = 0; i < count; i++)
        {
            sb.Append(' ');
            sb.Append("test");
        }

        return sb.ToString();
    }
    
    public static string BuildBetterV2(this string value, int count)
    {
        const string test = "test";
        var sb = new StringBuilder(value, (test.Length + 1) * count + value.Length);
        for (var i = 0; i < count; i++)
        {
            sb.Append(' ');
            sb.Append("test");
        }

        return sb.ToString();
    }

    public static (string FirstName, string LastName) NaiveSplitStringCommon(this string value)
    {
        var commaIndex = value.IndexOf(',');
        
        return (value.Substring(0, commaIndex), value.Substring(commaIndex + 2));
    }
    
    public static (string FirstName, string LastName) NaiveSplitStringOrdinalIgnoreCase(this string value)
    {
        var commaIndex = value.IndexOf(',', StringComparison.OrdinalIgnoreCase);
        
        return (value[..commaIndex], value[(commaIndex + 2)..]);
    }
    
    public static (string FirstName, string LastName) NaiveSplitStringCurrentCultureIgnoreCase(this string value)
    {
        var commaIndex = value.IndexOf(',', StringComparison.CurrentCultureIgnoreCase);
        
        return (value[..commaIndex], value[(commaIndex + 2)..]);
    }
    
    public static (string FirstName, string LastName) NaiveSplitStringInvariantCultureIgnoreCase(this string value)
    {
        var commaIndex = value.IndexOf(',', StringComparison.InvariantCultureIgnoreCase);
        
        return (value[..commaIndex], value[(commaIndex + 2)..]);
    }
    
    public static (string FirstName, string LastName) NaiveSplitStringOrdinal(this string value)
    {
        var commaIndex = value.IndexOf(',', StringComparison.Ordinal);
        
        return (value[..commaIndex], value[(commaIndex + 2)..]);
    }
    
    public static (string FirstName, string LastName) StringSplitString(this string value)
    {
        var nameArray = value.Split(',');

        return (nameArray[0].Trim(), nameArray[^1].Trim());
    }
    
    public static (string FirstName, string LastName) SpanSplitString(this string value)
    {
        var span = value.AsSpan();
        var commaIndex = span.IndexOf(',');
        
        var first = span[..commaIndex].ToString();
        var second = span[(commaIndex + 2)..].ToString();

        return (first, second);
    }
}