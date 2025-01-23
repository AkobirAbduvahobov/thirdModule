using System;

namespace ConsoleApp3._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new MusicCrudApiBroker();
        }



        public static void TupleInfo()
        {
            var res = GetMaxMin(43, 23, 33);
            Console.WriteLine(res.Item1);
            Console.WriteLine(res.Item2);
            Console.WriteLine(res);
        }

        public static (int, int) GetMaxMin(int a1, int a2, int a3)
        {
            var maxNum = Math.Max(a1, Math.Max(a2,a3));
            var minNum = Math.Min(a1, Math.Min(a2,a3));

            var res = (maxNum,  minNum);
            return res;
        }
    }
}
