using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp3._9;

internal class Program
{
    public delegate void SendMessage(string message);   
    public delegate double GetAnswer(double num1, double num2);


    static void Main(string[] args)
    {
        Func<int, int, int, int> func1 = Add;
        Func<int, int, int, int, int> func2 = Multiply;
    }

    // 🚀 Math & Number Functions
    public static int Add(int a, int b, int c) => a + b + c;
    public static int Multiply(int a, int b, int c, int d) => a * b * c * d;
    public static double Divide(double a, double b) => b != 0 ? a / b : double.NaN;
    public static (int sum, int product) SumAndProduct(int a, int b) => (a + b, a * b);
    public static bool IsEven(int num) => num % 2 == 0;

    // 🔥 String Manipulation
    public static string ConcatThree(string s1, string s2, string s3) => $"{s1}{s2}{s3}";
    public static (string upper, string lower) GetUpperAndLower(string str) => (str.ToUpper(), str.ToLower());
    public static bool ContainsSubstring(string main, string sub) => main.Contains(sub);
    public static string ReverseString(string str) => new string(str.Reverse().ToArray());

    // ✅ Array/List Functions
    public static int GetMax(params int[] numbers) => numbers.Max();
    public static int GetMin(params int[] numbers) => numbers.Min();
    public static int[] GetSorted(int[] numbers) => numbers.OrderBy(n => n).ToArray();
    public static (int max, int min) GetMaxAndMin(int[] numbers) => (numbers.Max(), numbers.Min());
    public static bool ContainsElement(int[] numbers, int value) => numbers.Contains(value);

    // ⚡ Random & Utility
    public static int GetRandomNumber(int min, int max) => new Random().Next(min, max);
    public static (int, int, int) GetRandomTriple() => (new Random().Next(1, 100), new Random().Next(1, 100), new Random().Next(1, 100));
    public static string GetCurrentDateTime() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    // 💡 Boolean & Conditions
    public static bool IsOdd(int num) => num % 2 != 0;
    public static bool IsPrime(int num)
    {
        if (num <= 1) return false;
        for (int i = 2; i * i <= num; i++)
            if (num % i == 0) return false;
        return true;
    }

    // 🚀 Tuple-Based Functions
    public static (double, double) GetCircleAreaAndCircumference(double radius)
    {
        double area = Math.PI * radius * radius;
        double circumference = 2 * Math.PI * radius;
        return (area, circumference);
    }

    public static (int sum, double average) SumAndAverage(int[] numbers)
    {
        int sum = numbers.Sum();
        double avg = numbers.Average();
        return (sum, avg);
    }

    // 🔄 Swapping & Printing
    public static void Swap(ref int a, ref int b) { int temp = a; a = b; b = temp; }
    public static void PrintMessage(string message) => Console.WriteLine(message);
    public static void PrintArray(int[] numbers) => Console.WriteLine(string.Join(", ", numbers));

    // 🛠️ Advanced Functions
    public static string FormatCurrency(double amount, string currency) => $"{currency} {amount:N2}";
    public static double CalculateDiscount(double price, double discountPercent) => price - (price * (discountPercent / 100));
    public static bool IsPalindrome(string str) => str == new string(str.Reverse().ToArray());
    public static int CountWords(string sentence) => sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

    public static (string first, string last) GetFirstAndLastWord(string sentence)
    {
        var words = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return (words.First(), words.Last());
    }



    // 🚀 List Functions
    public static List<int> FilterEvenNumbers(List<int> numbers) => numbers.Where(n => n % 2 == 0).ToList();
    public static List<string> ToUpperCaseList(List<string> strings) => strings.Select(s => s.ToUpper()).ToList();
    public static List<int> RemoveDuplicates(List<int> numbers) => numbers.Distinct().ToList();
    public static List<int> AddToList(List<int> numbers, params int[] additionalNumbers)
    {
        numbers.AddRange(additionalNumbers);
        return numbers;
    }

    // 🔥 Array Functions
    public static int[] FilterPositiveNumbers(int[] numbers) => numbers.Where(n => n > 0).ToArray();
    public static string[] ConvertToLowerCase(string[] words) => words.Select(w => w.ToLower()).ToArray();
    public static string[] RemoveEmptyStrings(string[] strings) => strings.Where(s => !string.IsNullOrEmpty(s)).ToArray();
    public static int[] SortArrayDescending(int[] numbers) => numbers.OrderByDescending(n => n).ToArray();

    // ✅ Dictionary Functions
    public static Dictionary<int, string> CreateDictionaryFromList(List<int> keys, List<string> values)
    {
        if (keys.Count != values.Count)
            throw new ArgumentException("Keys and values lists must have the same length.");

        return keys.Zip(values, (key, value) => new KeyValuePair<int, string>(key, value))
                   .ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    public static Dictionary<string, int> CountStringOccurrences(List<string> strings)
    {
        return strings.GroupBy(s => s)
                      .ToDictionary(group => group.Key, group => group.Count());
    }

    public static Dictionary<int, string> FilterDictionary(Dictionary<int, string> dictionary, string filter)
    {
        return dictionary.Where(pair => pair.Value.Contains(filter))
                         .ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    public static Dictionary<string, int> GetStringLengthDictionary(List<string> strings)
    {
        return strings.ToDictionary(str => str, str => str.Length);
    }

    // 🔄 Collection Manipulations
    public static List<int> MergeLists(List<int> list1, List<int> list2)
    {
        return list1.Concat(list2).ToList();
    }

    public static int[] MergeArrays(int[] array1, int[] array2)
    {
        return array1.Concat(array2).ToArray();
    }

    public static Dictionary<int, string> MergeDictionaries(Dictionary<int, string> dict1, Dictionary<int, string> dict2)
    {
        var merged = new Dictionary<int, string>(dict1);
        foreach (var pair in dict2)
        {
            if (!merged.ContainsKey(pair.Key))
            {
                merged.Add(pair.Key, pair.Value);
            }
        }
        return merged;
    }

    // 🛠️ Collection Transformations
    public static List<int> SquareNumbers(List<int> numbers) => numbers.Select(n => n * n).ToList();
    public static int[] GetSquares(int[] numbers) => numbers.Select(n => n * n).ToArray();
    public static List<string> FilterByLength(List<string> strings, int length) => strings.Where(s => s.Length > length).ToList();
















    static void Foo(string[] args)
    {
        // Func
        // Action
        // Predicate


        //Func<double, double, double> myFunc = Plus;
        //myFunc += Minus;

        //myFunc.Invoke(2,8);


        //Predicate<int> predicate = IsOdd;
        //var res = predicate.Invoke(1);
        //Console.WriteLine(res);


        //Predicate<int> predicate2 = (int num) => (num > 0);
        //Console.WriteLine(predicate2.Invoke(-52));



        //Action<string> sendMessage = SendMessageByEmail;
        //sendMessage += SendMessageByTelegram;

        //sendMessage.Invoke("salom g10");



        //MyClass.PrintDelegate printDelegate = (int num) => Console.WriteLine(num);

        ////MyClass myClass = new MyClass();
        ////myClass.MyClassDelegate = Display;

        //MyClass.PrintNumbers(printDelegate);
        //MyClass.PrintNumbers((int num) => Console.WriteLine(num));


        var nums = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
        };

        //Func<int, bool> func = (int num) => num % 2 == 0;

        //var res = nums.Where(func).ToList();

        Func<int, int> func = Double;

        var res = nums.Select(func).ToList();
        //foreach (int i in res) 
        //    Console.WriteLine(i);

        //nums.Sum(func);
    }

    public static int Double(int num)
    {
        return 2 * num;
    }

    //public static bool Do(int num) => num % 2 == 0;
    

    public static bool Do1(int num)
    {
        return num % 2 == 0;
    }


    public static bool IsOdd1(int num) => num % 2 != 0;
    public static bool IsPositive(int num) => (num > 0);
    


    public static void Display(int num)
    {
        Console.WriteLine(num);
    }
    

    public static double Plus(double num1, double num2)
    {
        Console.WriteLine("Plus");
        return num1 + num2;
    }

    public static double Minus(double num1, double num2)
    {
        Console.WriteLine("Minus");
        return num1 - num2;
    }


    public static void SendMessageByEmail(string message)
    {
        // email
        Console.WriteLine($"{message} Message is sent by email successfully");
    }

    public static void SendMessageByTelegram(string message)
    {
        Console.WriteLine($"{message} Message is sent by telegram successfully");
    }
}

