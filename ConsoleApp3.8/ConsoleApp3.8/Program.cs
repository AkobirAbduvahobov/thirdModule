namespace ConsoleApp3._8;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Main is started");
        var do1Task = Do1();
        var do2Task = Do2();
        var do3Task = Do3();

        //Do1();
        //Do2();
        //Do3();

        await do1Task;
        await do2Task;
        await do3Task;

        Console.WriteLine("Main is finished");
    }

    public static async Task Do1()
    {
        Console.WriteLine("Do1 is started");
        await Task.Delay(6000);
        Console.WriteLine("Do1 is finished");
    }

    public static async Task Do2()
    {
        Console.WriteLine("Do2 is started");
        await Task.Delay(5000);
        Console.WriteLine("Do2 is finished");
    }

    public static async Task Do3()
    {
        Console.WriteLine("Do3 is started");
        await Task.Delay(4000);
        Console.WriteLine("Do3 is finished");
    }








    public static async Task<string> GetTea()
    {
        var boiledWaterTask = await BoilWater();

        Console.WriteLine("Shkafdan choynakni oldik");

        Console.WriteLine("Choynakga quruq choy soldik");

        var res = $"Choynakga {boiledWaterTask} quydik";

        Console.WriteLine(res);

        return res;
    }

    public static async Task<string> BoilWater()
    {
        Console.WriteLine("Tifalni yoqdik");

        await Task.Delay(5000);

        Console.WriteLine("Suv qaynadi");

        return "qaynagan suv";
    }
}










