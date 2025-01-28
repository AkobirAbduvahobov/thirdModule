namespace _3._6dars;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Main is started");

        HttpClientClass httpClientClass = new HttpClientClass();

        await httpClientClass.GetAll();

        Console.WriteLine("Main is finished 3.6");
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
