using System;
using System.Runtime.InteropServices;

namespace C__GC
{
    class Programe
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Game game = new Game();
            game.Start();
        }
    }
}