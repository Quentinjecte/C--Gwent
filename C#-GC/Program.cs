using System;

namespace C__GC
{
    class Programe
    {
        public static void Main(string[] args)
        {
            int left = Console.LargestWindowWidth - Console.WindowWidth;
            int top = Console.LargestWindowHeight - Console.WindowHeight;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.SetWindowPosition(0, 0);

            Game game = new Game();
            game.Start();
        }
    }
}