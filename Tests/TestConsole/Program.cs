using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

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

            //MyThreadClass.NumF = int.Parse(Console.ReadLine());
            //MyThreadClass.NumS = int.Parse(Console.ReadLine());
            //var thread_one = new Thread(MyThreadClass.FactorialCalculating);
            //var thread_two = new Thread(MyThreadClass.SumCalculating);
            //thread_one.Start();
            //thread_two.Start();
            //thread_one.Join();
            //thread_two.Join();
            //Parallel.Invoke(new ParallelOptions {MaxDegreeOfParallelism = 3},MyThreadClass.FactorialCalculating,MyThreadClass.SumCalculating, MyThreadClass.FactorialCalculating);


            var messages = Enumerable.Range(1, 1000).Select(i => $"Message{i}");
            //var selected_message = messages.Select((m) => (msg: m, length: m.Length)).Where(m => m.msg.EndsWith("20")).ToArray();

            //var selected_messages = from t in messages where t.EndsWith("20") select new {msg = t, length = t.Length};
            var selected_messages = messages.Where((m) => m.EndsWith("20")).Select((m) => (msg: m, length: m.Length))
                .ToArray();

            foreach (var sm in selected_messages)
            {
                Console.WriteLine($"{sm.msg}:{sm.length}");
            }
            Console.ReadLine();
        }
    }

}
