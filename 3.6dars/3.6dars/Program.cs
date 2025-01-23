using System;

namespace _3._6dars;

internal class Program
{
    static void Main(string[] args)
    {
        //(int, string) myValue = (45, "salom");
        //Console.WriteLine(myValue.Item1);
        //Console.WriteLine(myValue.Item2);

        var res = GetMaxMin(43, 55, 12);
        Console.WriteLine(res.Item1);
        Console.WriteLine(res.Item2);

    }

    public static (int, int) GetMaxMin(int num1, int num2, int num3)
    {
        var res = (0, 0);
        res.Item1 = Math.Max(num1, Math.Max(num2, num3));
        res.Item2 = Math.Min(num1, Math.Min(num2, num3));
        return res;
    }



    public static void SingletonInfo()
    {
        var myClass1 = MyClass.GetInstanse();
        myClass1.Id = 1;
        var myClass2 = MyClass.GetInstanse();
        myClass2.Id = 2;
        var myClass3 = MyClass.GetInstanse();
        myClass3.Id = 3;

        Console.WriteLine(myClass1.Id);
        Console.WriteLine(myClass2.Id);
        Console.WriteLine(myClass3.Id);

        bool res1 = object.ReferenceEquals(myClass1, myClass2);
        bool res2 = object.ReferenceEquals(myClass1, myClass2);
        bool res3 = object.ReferenceEquals(myClass1, myClass2);
        Console.WriteLine(res1);
        Console.WriteLine(res2);
        Console.WriteLine(res3);
    }
}
