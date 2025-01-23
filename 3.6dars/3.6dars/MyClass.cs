namespace _3._6dars;

public class MyClass
{
    public long Id { get; set; }
    private static MyClass _instanse;
    private MyClass() { }
   

    public static MyClass GetInstanse()
    {
        if(_instanse == null)
        {
            _instanse = new MyClass();
        }

        return _instanse;
    }
}
