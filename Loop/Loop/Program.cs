using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            LoopWithInt();
            LoopWithString();

            Console.ReadLine();
        }

        public static void LoopWithString()
        {
            Loop<string>("a",
                s => s != "aaaaaaaa",
                s => Console.WriteLine($"I have received {s}"),
                s => s + s
                );
        }

        public static void LoopWithInt()
        {
            int loopEnd = 10;

            Loop<int>(1,
                i => i <= loopEnd,
                i => Console.WriteLine($"I got {i}"),
                i => i + 1);
        }

        public static void Loop<T>(
            T value,
            Func<T,bool> Test,
            Action<T> Body,
            Func<T,T> Update)
        {
            if(Test(value))
            {
                Body(value);
                Loop(Update(value),Test,Body,Update);
            }
            return;
        }
            
    }
}
