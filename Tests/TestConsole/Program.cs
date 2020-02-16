using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //EventsTest test = new EventsTest();
            //KeyPresser keyPresser = new KeyPresser();
            //test.OnMethod += keyPresser.Message;
            //var thread = new Thread(() => keyPresser.Changing()) { IsBackground = true };
            //thread.Start();
            //test.RunTest();

            MyThreadClass.NumF = int.Parse(Console.ReadLine());
            MyThreadClass.NumS = int.Parse(Console.ReadLine());
            var thread_one = new Thread(MyThreadClass.FactorialCalculating);
            var thread_two = new Thread(MyThreadClass.SumCalculating);
            thread_one.Start();
            thread_two.Start();
            thread_one.Join();
            thread_two.Join();
        }
    }

}
