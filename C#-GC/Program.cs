namespace C__GC
{
    class Programe
    {
        public static void Main(string[] args)
        {
            /*            StateManager stateManager = new StateManager();
                        Console.WriteLine(stateManager.GetCurrentState()); // affiche le state actuel
                        stateManager.ChangeState(State.Fight);
                        Console.WriteLine(stateManager.GetCurrentState()); // affiche le nouveau state*/

            Overlay overlay = new Overlay();
            overlay.InitPopUp();

            /*            Game game = new Game();
                        game.Start();*/
        }
    }
}
