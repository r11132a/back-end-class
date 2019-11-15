using System;
using System.Collections.Generic;

namespace AnyAll
{
    internal class Program
    {
        private static void Main()
        {
            int[] a1 = { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine("a1 = { 1, 2, 3, 4, 5, 6 }");
            Console.WriteLine($"All of a1 are greater than 0: {All(a1, i => i > 0)}");
            Console.WriteLine($"At least one member of a1 is greater than 5: {Any(a1, i => i > 5)}");

            Console.WriteLine($"All of a1 are even: {All(a1, i => i % 2 == 0)}");
            Console.WriteLine($"At least one member of a1 is greater than 6: {Any(a1, i => i > 6)}");

            List<int> l1 = new List<int> { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine("l1 = { 1, 2, 3, 4, 5, 6 }");
            Console.WriteLine($"All of l1 are greater than 0: {All(l1, GreaterThan0)}");
            Console.WriteLine($"At least one member of l1 is greater than 5: {Any(l1, GreaterThan5)}");

            Console.WriteLine($"All of l1 are even: {All(l1, IsEven)}");
            Console.WriteLine($"At least one member of l1 is greater than 6: {Any(a1, GreaterThan6)}");

            Console.ReadLine();
        }

        public static bool GreaterThan5(int i)
        {
            return i > 5;
        }

        public static bool GreaterThan6(int i)
        {
            return i > 6;
        }

        public static bool GreaterThan0(int i)
        {
            return i > 0;
        }

        public static bool IsEven(int i)
        {
            return i % 2 == 0;
        }

        public static bool Any<T>(IEnumerable<T> collection, Func<T, bool> func)
        {
            foreach (var item in collection)
                if (func(item)) return true;
            return false;
        }

        public static bool All<T>(IEnumerable<T> collection, Func<T, bool> func)
        {
            foreach (var item in collection)
                if (!(func(item))) return false;
            return true;
        }
    }
}