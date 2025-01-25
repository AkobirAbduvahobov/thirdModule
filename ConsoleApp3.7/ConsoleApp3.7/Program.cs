using System.Diagnostics;

namespace ConsoleApp3._7;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Main is started");
        //Console.WriteLine($"ThredId : {Thread.CurrentThread.ManagedThreadId}");

        //Thread thread1 = new Thread(CountUp)
        //{
        //    Name = "oshpaz1"
        //};

        //Thread thread2 = new Thread(CountDown)
        //{
        //    Name = "ozshpaz2"
        //};

        //thread1.Start();
        //thread2.Start();

        //thread1.Join();
        //thread2.Join();

        //Console.WriteLine("Main is finished");
        //Console.WriteLine($"ThredId : {Thread.CurrentThread.ManagedThreadId}");

        string diroctoryPath = @"D:\Work\Groups\G_10_C#\Classwork\3.7 tasks";
        var filesPath = Directory.GetFiles(diroctoryPath);

        var finish = 0;
        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();

        //Console.WriteLine("Main is started");
        //Thread thread1 = new Thread(() => IncrementNumber("salom"));
        //Thread thread2 = new Thread(() => IncrementNumber("salom"));

        //thread1.Start();
        //thread2.Start();

        //thread1.Join();
        //thread2.Join();

        //Console.WriteLine($"Finish : {_counter}");
        //stopwatch.Stop();
        //Console.WriteLine(stopwatch.ToString());
    }

    public static int _counter = 0;
    public static Object _lock = new Object();

    public static void IncrementNumber(string filePath)
    {
        for (int i = 0; i < 10; i++)
        {
            lock (_lock)
            {
                ++_counter;
                Console.WriteLine("counter : " + _counter);
                Console.WriteLine($"ThreadId : {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"ThreadId : {Thread.CurrentThread.ThreadState}");
            }

            Thread.Sleep(1000);
        }
    }

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
