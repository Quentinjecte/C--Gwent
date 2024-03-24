using System.Drawing;

namespace C__GC
{

    struct Inventory
    {
        int golds;
        int soulTokens;
    }


    internal class Player
    {
/*
------------------------------------------------------
|             Initialize Varialbe Player.cs          |                     
------------------------------------------------------
*/
        private string _map;
        private int _size;
        public int playerX = 10;
        public int playerY = 10;
        DisplayElement _playerRender;

        //Overlay overlay = new();
        Random rdm = new();

/*
------------------------------------------------------
|             Initialize Function Player.cs          |                     
------------------------------------------------------
*/
        public Player()
        {
        }
        public void InitPlayer(string map, int size)
        {
            _map = map;
            _size = size;
            _playerRender.content = "p";
            _playerRender.width = 1;
            _playerRender.xOffset = playerX;
            _playerRender.yOffset = playerY;
            DisplaySystem.Subscribe(_playerRender);
        }
        //saveS
        public void Input(int x, int y)
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Z:
                        (x, y) = (0, -1);
                        break;
                    case ConsoleKey.S:
                        (x, y) = (0, 1);
                        break;
                    case ConsoleKey.Q:
                        (x, y) = (-1, 0);
                        break;
                    case ConsoleKey.D:
                        (x, y) = (1, 0);
                        break;
                    default:
                        continue;
                }

                int newX = playerX + x;
                int newY = playerY + y;

                if (IsObstacle(newX, newY) == false)
                {
                    SetBack(playerX, playerY);
                    Move(x, y);
                    if(IsGrass(newX, newY))
                    {
                        if(rdm.Next(0, 1) == 0)
                        {
                            Stats stats = new Stats();
                            stats.mana = 200;
                            stats.hp = 100;
                            stats.atk = 10;

                            Protagonist prota = new Protagonist("jenti", stats);



                            Battle battle = new Battle([prota], [EnemyFactory.basic(), EnemyFactory.basic()]);
                            if(battle.start() == false)
                            {
                                return;
                            }
                        }
                    }
                }

            } while (true);
        }
        private void Move(int x, int y)
        {
            DisplayElement oldRender = _playerRender;
            playerX += x;
            playerY += y;
            _playerRender.xOffset = playerX;
            _playerRender.yOffset = playerY;
            DisplaySystem.ReplaceByValue(oldRender, _playerRender);
            DisplaySystem.Update();
            
        }
        private bool IsObstacle(int x, int y)
        {
            return _map[y * _size + x] == '#';
        }
        private bool IsGrass(int x, int y)
        {
            return _map[y * _size + x] == '@';
        }
        public void SetBack(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(_map[y * _size + x]);
        }
    }
}
