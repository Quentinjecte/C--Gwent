namespace C__GC
{
    class Programe
    {
        public static void Main(string[] args)
        {
            StateManager stateManager = new StateManager();
            Console.WriteLine(stateManager.GetCurrentState()); // affiche le state actuel
            stateManager.ChangeState(State.Fight);
            Console.WriteLine(stateManager.GetCurrentState()); // affiche le nouveau state

            Game game = new Game();
            game.Start();
            string assetsPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "C:\\Users\\Tom\\source\\repos\\C--Gwent\\C#-GC\\assets\\testMap.bmp");
            MapParser parser = new MapParser();
            Console.WriteLine(parser.ParseBitmap(assetsPath, 100));
        }
    }
}
