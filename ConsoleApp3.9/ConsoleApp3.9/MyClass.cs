namespace ConsoleApp3._9;

public class MyClass
{
    public delegate void PrintDelegate(int number);
    public PrintDelegate MyClassDelegate { get; set; }

    public static void PrintNumbers(PrintDelegate printDelegate)
    {
        for (int i = 0; i < 10; i++)
        {
            printDelegate.Invoke(i);
        }
    }
}
