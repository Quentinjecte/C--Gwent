namespace C__GC
{
    class Programe
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            //string assetsPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "testMap.bmp");
            using(StreamReader map = new StreamReader("../../../map.txt"))
            {
                string str = map.ReadToEnd().Replace("\\e", "\x1b");
                map.Close();
                Console.Write(str);
            }
            //MapParser parser = new MapParser();
            //Console.WriteLine(parser.ParseBitmap(assetsPath, 100));
            //Console.WriteLine(assetsPath);
            //Protagonist[] prota = {new Protagonist()};
            //Character[] enemy = {new Character()};
            //Battle battle = new Battle(prota, enemy);
            //battle.start();
        }
    }
}