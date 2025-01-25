using System.Text.RegularExpressions;

namespace ConsoleApp3._7;

internal class Program
{

    static void Main(string[] args)
    {
        //var drPath = @"D:\Work\Groups\G_10_C#\Classwork\3.7_tasks";

        //var files = Directory.GetFiles(drPath).ToList();

        //foreach (var file in files)
        //{
        //    if (file.Contains("results")) continue;
        //    var thread = new Thread(() => WriteNumberOfDigitsToFile(file));
        //    thread.Start();
        //}

        Console.WriteLine(ValidateName("Akobir"));
        Console.WriteLine(ValidateName("hello"));
        Console.WriteLine(ValidateName("Akobir212"));
        Console.WriteLine(ValidateName("Ako bir"));
        Console.WriteLine(ValidateName("AKobir"));
        Console.WriteLine(ValidateName("Umar"));

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
