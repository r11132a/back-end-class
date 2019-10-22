using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwo
{
    class Program
    {
        static int Main()
        {
            Console.WriteLine("Choose a function: ");
            Console.WriteLine("1. Min");
            Console.WriteLine("2. CountChar");
            Console.WriteLine("3. Range Functions");
            Console.WriteLine("4. IsEven functions");
            Console.WriteLine("5. Reverse Arrays");
            var command = Console.ReadLine();

            switch(command)
            {
                case "1":
                    try
                    {
                        RunMin();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"User could not follow directions: {e.Message}");
                        Console.WriteLine(e.StackTrace);
                    }
                    break;

                case "2":
                    Console.Write("Enter a string:  ");
                    string inputString = Console.ReadLine();
                    Console.Write("Enter a character to search for: ");
                    char searchChar = Console.ReadLine()[0];
                    Console.WriteLine($"Found {CountChar(inputString, searchChar)} '{searchChar}' in '{inputString}'");
                    break;

                case "3":
                    Console.Write("Enter start and stop integer values:  ");
                    string input = Console.ReadLine();
                    string[] numbers = input.Split(' ');
                    Console.WriteLine($"Sum of the range is: {SumOfRange(MakeRange(Int32.Parse(numbers[0]),Int32.Parse(numbers[1])))}");
                    break;

                case "4":
                    Console.Write("Enter a number to determine if it is even:  ");
                    int number = Int32.Parse(Console.ReadLine());
                    Console.WriteLine($"IsEvenRecusive({number}) says {number} is {(IsEvenRecursive(number) ? "Even" : "Odd")}"); ;
                    Console.WriteLine($"IsEven({number}) says {number} is {(IsEven(number) ? "Even" : "Odd")}");
                    break;

                case "5":
                    Console.Write("Enter two numbers, seperated by a space, to generate an array:  ");
                    input = Console.ReadLine();
                    numbers = input.Split(' ');
                    int[] arrayData = MakeRange(Int32.Parse(numbers[0]), Int32.Parse(numbers[1]));
                    Console.WriteLine(String.Join(", ",arrayData));
                    Console.WriteLine("ReverseArray:");
                    Console.WriteLine(String.Join(", ", ReverseArray(arrayData)));
                    Console.WriteLine("ReverseInPlace:");
                    ReverseInPlace(arrayData);
                    Console.WriteLine(String.Join(", ", arrayData));
                    break;
            }


            return 0; // This is a good place for a breakpoint!
        }

        public static bool IsEvenRecursive(int number)
        {
            switch(number)
            {
                case 0:
                    return true;
                case 1:
                    return false;
                default:
                    return IsEvenRecursive(number - 2);
            }
        }

        public static bool IsEven(int number) => number % 2 == 0 ? true : false;

        public static int[] ReverseArray(int[] array)
        {
            int[] reversedArray = new int[array.Length];

            for(int i = array.Length - 1;i >= 0;i--)
            {
                reversedArray[array.Length - 1 - i] = array[i];
            }

            return reversedArray;
        }

        public static void ReverseInPlace(int[] array)
        {
            int[] oldArray = new int[array.Length];
            array.CopyTo(oldArray, 0);

            for(int i = array.Length - 1;i >= 0;i--)
            {
                array[array.Length - 1 - i] = oldArray[i];
            }
        }

        /*
         * 
         *  Mostly observing the spirit of the assignment... 
         * 
         */

        static int[] MakeRange(int start, int end, int step = 1)
        {
            // Yeah, it's probably cheating...
            List<int> theRange = new List<int>();

            for(int i = start;i <= end;i += step)
            {
                theRange.Add(i);
            }

            return theRange.ToArray();
        }

        static int SumOfRange(int[] theRange)
        {
            int sum = 0;

            foreach(int i in theRange)
            {
                sum += i;
            }

            return sum;
        }


        /**
         * 
         * Keeping with the spirit of the exercise and searching/counting with a loop.
         * 
         */
        public static int CountChar(string inputString,char searchChar)
        {
            int count = 0;
            foreach(char c in inputString)
            {
                if (c == searchChar) ++count;
            }

            //However
            //inputString.Select(c => c == searchChar ? 1 : 0).Sum();

            return count;
        }

        /**
         * 
         * Used some exceptions to coincide with Chapter 7.  Used different exceptions to show 
         * familiarity with different built in exceptions.  Would not usually use so many different
         * exceptions in this case.
         * 
         */

        private static void RunMin()
        {
            Console.Write("Enter two integers seperated by a space:  ");
            string inputString = Console.ReadLine();
            if (inputString.Equals(string.Empty))
            {
                throw new Exception("No data entered!");
            }
            string[] numbers = inputString.Split(' ');
            if (numbers.Length < 2)
            {
                throw new ApplicationException("Not enough numbers entered");
            }
            if (!Int32.TryParse(numbers[0], out int a))
            {
                throw new ArgumentException("First value could not be parsed as an integer");
            }
            if (!Int32.TryParse(numbers[1], out int b))
            {
                throw new ArgumentException("Second value could not be parsed as an integer");
            }

            Console.WriteLine($"Min({a},{b}) == {Min(a, b)}");
        }

        public static int Min(int a, int b) => (a < b) ? a : b;
    }

    
}