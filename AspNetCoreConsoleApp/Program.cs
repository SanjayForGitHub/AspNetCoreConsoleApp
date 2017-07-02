using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreConsoleApp
{
    public static class MyLyncImplementation
    {
        //public static IEnumerable<string> Where(this IEnumerable<string> source, Func<string, bool> predicate)
        //{
        //    Console.WriteLine("test2");
        //    foreach (var item in source)
        //        if (predicate(item))
        //            yield return item;
        //}
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Console.WriteLine("test");
            foreach (var item in source)
                if (predicate(item))
                    yield return item;
        }
        public static IEnumerable<string> Select(this IEnumerable<string> source, Func<string, string> selector) {
            foreach (var item in source)
                yield return selector(item);
        }
        /// <summary>
        /// This is created By Sanjay
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<string> Select(this IEnumerable<int> source, Func<int, string> selector) {
            Console.WriteLine("MY IMPLEMNTATION");
            foreach (var item in source)
                yield return selector(item);
            Console.WriteLine("MY IMPLEMNTATION");
        }
    }
    class Program
    {
        private static IEnumerable<string> GenerateSequence()
        {
            for (int i = 0; i < 100; i++)
            {
                yield return i.ToString();
            }
        }
        private static IEnumerable<int> GenerateNumbers()
        {
            for (int i = 0; i < 100; i++)
            {
                yield return i;
            }
        }
        static void Main(string[] args)
        {
            //var sequence = GenerateSequence();
            //sequence = sequence.Where(s => s.Length < 2);

            //var sequence = GenerateSequence().Where(parm => 
            //{
            //    if (parm == "9")
            //        return true;
            //    else
            //        return false;
            //});
            var sequence = GenerateNumbers().Select(intValue => intValue);
            foreach (var item in sequence)
            {
                Console.WriteLine(item);
            }

        }
        //Basic IEnumerator
        //static void Main(string[] args) {
        //    int i = 0;

        //    foreach (var item in GeneratedStrings(() => i++.ToString()).Take(100))
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadLine();
        //}
        //private static IEnumerable<string> GeneratedStrings() {
        //    for (int i = 0; i < int.MaxValue; i++)
        //    {
        //        yield return i.ToString();
        //    }
        //}
        //private static IEnumerable<T> GeneratedStrings<T>(Func<T> itemGenerator)
        //{
        //    for (int i = 0; i < int.MaxValue; i++)
        //    {
        //        yield return itemGenerator();
        //    }
        //}
        ////Delegates
        //public delegate double CalculateInterest(double d1, double d2, double d3);
        //static CalculateInterest CI = CalculateInt;
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(CI.Invoke(1, 2, 3));
        //    CI += PartialCalculateInt;
        //    Console.WriteLine(CI.Invoke(1, 2, 3));
        //    CalculateInterest CI2 = (x2, x3, x4) => { Console.WriteLine(x2); double d2 = 2.5d; return d2; };
        //    CI2(1, 2, 3);
        //    Console.WriteLine("Hello World!");
        //}
        //static double CalculateInt(double d1, double d2, double d3) {
        //    return (d1 * d2 * d3)/ 100;
        //}
        //static double PartialCalculateInt(double d1, double d2, double d3)
        //{
        //    return (d1 * d2 * d3) / 50;
        //}
    }
}