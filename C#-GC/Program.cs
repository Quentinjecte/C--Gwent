namespace C__GC
{
    class Programe
    {
        public static void Main(string[] args)
        {
            //Game game = new Game();
            //game.Start();
            string assetsPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "testMap.bmp");
            MapParser parser = new MapParser();
            Console.WriteLine(parser.ParseBitmap(assetsPath, 100));
        }
    }
}
