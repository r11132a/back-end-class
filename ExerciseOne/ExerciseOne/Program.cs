using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOne
{
    class Program
    {
        static int Main(string[] args)
        {

            /*  Menu */
            Console.WriteLine("Exercise One");
            Console.WriteLine("Select number to run");
            Console.WriteLine("1. Triangle (default size 6)");
            Console.WriteLine("2. FizzBuzz");
            Console.WriteLine("3. ChessBoard (default size 8)");
            var response = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Begin Output:");
            Console.WriteLine("*-----------------------------*");
            switch (response) {
                case "1": 
                    Triangle();
                    break;
                case "2":
                    FizzBuzz();
                    break;
                case "3":
                    ChessBoard();
                    break;
                default: 
                    Console.WriteLine($"{response} isn't a valid option");
                    break;
            }
            Console.WriteLine("*-----------------------------*");
            return 0;
        }

        #region Triangle
        static void Triangle(int size = 6)
        {
            for(int i = 0;i < size;i++)
            {
                for(int j = 0;j < i+1;j++)
                {
                    Console.Write('#');
                }

                Console.WriteLine();
            }
        }
        #endregion

        #region FizzBuzz
        static void FizzBuzz()
        {
            for(int i = 0;i <= 100;++i)
            {
                switch(i)
                {
                    case int j when (i % 3 == 0 && i % 15 != 0):
                        Console.WriteLine("Fizz");
                        break;
                    case int j when (i % 5 == 0 && i % 15 != 0):
                        Console.WriteLine("Buzz");
                        break;
                    case int j when i % 15 == 0:
                        Console.WriteLine("FizzBuzz");
                        break;
                    default:
                        Console.WriteLine(i);
                        break;
                }
            }
        }
        #endregion

        #region ChessBoard
        static void ChessBoard(int size = 8)
        {
            for(int i = 0;i < size;i++)
            {
                for(int j = 0;j < size;j++)
                {
                    Console.Write("{0}",
                        ((i + j) % 2 == 0 ? ' ' : '#'));
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
