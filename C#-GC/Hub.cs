using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    internal class Hub
    {
        private int HubIndex;
        private string[] Options;
        private string Prompt;

        public Hub(string _Prompt, string[] _Options)
        {
            Prompt = _Prompt;
            Options = _Options;
            HubIndex = 0;
        }

        private void OverlayOption()
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string ActChoise;
                string CurrentOption = Options[i];

                if (i == HubIndex)
                {
                    ActChoise = "->";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    ActChoise = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{ActChoise}  {CurrentOption}");
            }
            Console.ResetColor();
        }

        public int SwapIndex()
        {
            ConsoleKey KeyPress;

            do
            {
                Console.Clear();
                OverlayOption();

                ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
                KeyPress = KeyInfo.Key;


                if (KeyPress == ConsoleKey.UpArrow)
                {
                    HubIndex--;
                    if (HubIndex == -1)
                    {
                        HubIndex = Options.Length - 1;
                    }
                }
                else if (KeyPress == ConsoleKey.DownArrow)
                {
                    HubIndex++;
                    if (HubIndex == Options.Length)
                    {
                        HubIndex = 0;
                    }
                }
            }
            while (KeyPress != ConsoleKey.Escape);


            return HubIndex;
        }

        public void NewGame()
        {

        }

        public void Continue()
        {

        }

        public void Option()
        {

        }

        public void Credit()
        {
            Console.Clear();
            Console.Write("\n Game designed by Gwent\n");
        }

        public void Exit()
        {
            Console.Write("\n Press 'Escape' to exit");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}