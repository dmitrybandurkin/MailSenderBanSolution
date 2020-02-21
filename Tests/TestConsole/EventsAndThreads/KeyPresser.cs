using System;

namespace TestConsole
{
    class KeyPresser
    {
        private string[] str;
        private string currentString = "";

        public KeyPresser()
        {
            str = new string[] { "Внезапно", "Вдруг", "Неожиданно" };
        }
        public void Changing()
        {
            int i=0;
            while(true)
            {
                i = (i >= 2) ? 0 : ++i;
                currentString = str[i];
            }
        }
        public void Message(ConsoleKeyInfo key) => Console.WriteLine($"{currentString} нажата кнопка {key.KeyChar}");
    }

}
