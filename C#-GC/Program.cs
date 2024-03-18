using System;
using System.Drawing;
using System.Windows.Forms;

namespace C__GC
{
    class Programe
    {
        public static void Main(string[] args)
        {
            //Game game = new Game();
            //game.Start();
            string assetsPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "C:\\Users\\Askeladd\\Desktop\\CODE\\C--Gwent\\C#-GC\\assets\\testMap.bmp");
            MapParser parser = new MapParser();
            Console.WriteLine(parser.ParseBitmap(assetsPath, 100));
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
