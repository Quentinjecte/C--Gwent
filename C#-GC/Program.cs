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