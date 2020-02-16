using System;

namespace TestConsole
{
    public class EventsTest
    {
        public delegate void Method(ConsoleKeyInfo key);
        public event Method OnMethod;
        public void RunTest()
        {
            ConsoleKeyInfo key;
            while(true)
            {
                key = Console.ReadKey(true);
                OnMethod(key);
            }
        }
    }

}
