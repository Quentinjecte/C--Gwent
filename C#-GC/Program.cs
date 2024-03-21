using System;

namespace C__GC
{
    class Programe
    {
        public static void Main(string[] args)
        {
            /*int left = Console.LargestWindowWidth - Console.WindowWidth;
            int top = Console.LargestWindowHeight - Console.WindowHeight;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.SetWindowPosition(0, 0);


            Game game = new Game();
            game.Start();*/


            Stats stats = new Stats();
            stats.mana = 200;
            stats.hp = 100;
            stats.atk = 10;

            Character enemy = new Character("vilain", stats);
            Protagonist prota = new Protagonist("jenti", stats);

            

            Battle battle = new Battle([prota], [enemy]);
            battle.start();


            //string assetsPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "testMap.bmp");
            //MapParser parser = new MapParser();
            //Console.WriteLine(parser.ParseBitmap(assetsPath, 100));

            //Protagonist[] prota = {new Protagonist()};
            //Character[] enemy = {new Character()};
            //Battle battle = new Battle(prota, enemy);
            //battle.start();
        }
    }
}