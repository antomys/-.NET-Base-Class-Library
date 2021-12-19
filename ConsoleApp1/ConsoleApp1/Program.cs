namespace ConsoleApp1;

enum Test1 {None = 0}
enum Test2 {None = 400}
class Program {
    static void Main(string[] args)
    {
        var a1 = EnumExtensions.Parse(Test1.None);
        var a2 = EnumExtensions.Parse(Test2.None);
    }

    static class EnumExtensions
    {
        public static int Parse<TEnum>(TEnum value)
            where TEnum : Enum
        {
            return Enum.Parse<TEnum>(value)''
        }
    }
} 