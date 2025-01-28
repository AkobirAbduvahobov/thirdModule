using System.Diagnostics;
using System.Text.RegularExpressions;
using test;

namespace ConsoleApp3._7;

internal class Program
{

    static async Task Main(string[] args)
    {
        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();
        //Console.WriteLine("Main is started");

        //var do1Task = Do1();
        //var do2Task = Do2();
        //var do3Task = Do3();

        ////Do1();
        ////Do2();
        ////Do3();

        ////Task.WaitAll(do1Task, do2Task, do3Task);
        //var allTask = Task.WhenAll(do1Task, do2Task, do3Task);

        //Console.WriteLine("salom Dunyo");

        //await allTask;  


        //await do1Task;
        //await do2Task;
        //await do3Task;

        //stopwatch.Stop();
        //Console.WriteLine(stopwatch.ToString());

        //Console.WriteLine("Main is finished");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        var folderpath = @"D:\Work\Groups\G_10_C#\Classwork\3.7_tasks";
        var files = Directory.GetFiles(folderpath);

        var tasks = files
            .Select(file => Task.Run(() => WriteNumberOfDigitsToFile(file)));

        await Task.WhenAll(tasks);

        stopwatch.Stop();
        Console.WriteLine(stopwatch.ToString());

        Console.WriteLine("Finish");

        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();

        //var folderpath = @"D:\Work\Groups\G_10_C#\Classwork\3.7_tasks";
        //var files = Directory.GetFiles(folderpath);

        //foreach (var file in files)
        //{
        //    var thread = new Thread(() => WriteNumberOfDigitsToFile(file));
        //    thread.Start();
        //}

        //stopwatch.Stop();
        //Console.WriteLine(stopwatch.ToString());

        //Console.WriteLine("Finish");
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

    public static bool ValidateName(string name)
    {
        string namePattern = @"^[A-Z]{1}[a-z]+$";
        var res = Regex.IsMatch(name, namePattern);
        return res;
    }




    public static void WriteNumberOfDigitsToFile(string filePath)
    {
        var resultPath = @"D:\Work\Groups\G_10_C#\Classwork\3.7_tasks\results.txt";

        if(filePath == resultPath)
        {
            return;
        }

        lock (_lock)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            using (var sr = new StreamReader(filePath))
            {
                var lines = sr.ReadToEnd();
                var count = lines.Count(ch => Char.IsDigit(ch));
                using (StreamWriter stream = new StreamWriter(resultPath, true))
                {
                    var id = Thread.CurrentThread.ManagedThreadId;
                    var line = $"ThreadId : {id}, Path : {filePath}, Count : {count}";
                    stream.WriteLine(line);
                }
            }
        }
    }


    public static Object _lock = new Object();

    //static void Main(string[] args)
    //{
    //    //Console.WriteLine("Main is started");
    //    //Console.WriteLine($"ThredId : {Thread.CurrentThread.ManagedThreadId}");

    //    //Thread thread1 = new Thread(CountUp)
    //    //{
    //    //    Name = "oshpaz1"
    //    //};

    //    //Thread thread2 = new Thread(CountDown)
    //    //{
    //    //    Name = "ozshpaz2"
    //    //};

    //    //thread1.Start();
    //    //thread2.Start();

    //    //thread1.Join();
    //    //thread2.Join();

    //    //Console.WriteLine("Main is finished");
    //    //Console.WriteLine($"ThredId : {Thread.CurrentThread.ManagedThreadId}");

    //    string diroctoryPath = @"D:\Work\Groups\G_10_C#\Classwork\3.7 tasks";
    //    var filesPath = Directory.GetFiles(diroctoryPath);

    //    var finish = 0;
    //    //Stopwatch stopwatch = new Stopwatch();
    //    //stopwatch.Start();

    //    //Console.WriteLine("Main is started");
    //    //Thread thread1 = new Thread(() => IncrementNumber("salom"));
    //    //Thread thread2 = new Thread(() => IncrementNumber("salom"));

    //    //thread1.Start();
    //    //thread2.Start();

    //    //thread1.Join();
    //    //thread2.Join();

    //    //Console.WriteLine($"Finish : {_counter}");
    //    //stopwatch.Stop();
    //    //Console.WriteLine(stopwatch.ToString());
    //}

    //public static int _counter = 0;
    //public static Object _lock = new Object();

    //public static void IncrementNumber(string filePath)
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        lock (_lock)
    //        {
    //            ++_counter;
    //            Console.WriteLine("counter : " + _counter);
    //            Console.WriteLine($"ThreadId : {Thread.CurrentThread.ManagedThreadId}");
    //            Console.WriteLine($"ThreadId : {Thread.CurrentThread.ThreadState}");
    //        }

    //        Thread.Sleep(1000);
    //    }
    //}

    //public static void CountUp()
    //{
    //    for (int i = 0; i <= 10; i++)
    //    {
    //        Console.WriteLine($"{i} : CountUp, ThredId : " +
    //            $"{Thread.CurrentThread.ManagedThreadId}, {Thread.CurrentThread.Name}");
    //        Thread.Sleep(1000);
    //    }
    //}

    //public static void CountDown()
    //{
    //    for (int i = 10; i >= 0; i--)
    //    {
    //        Console.WriteLine($"{i} : CountDown, ThredId : " +
    //            $"{Thread.CurrentThread.ManagedThreadId}, {Thread.CurrentThread.Name}");
    //        Thread.Sleep(1000);
    //    }
    //}
}
