using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{

    struct Inventory
    {
        int golds;
        int soulTokens;
    }


    internal class Player
    {
        enum MoveDirection
        {
            Forward,
            Backward,
            Left,
            Right
        }

        public int playerX = 10;
        public int playerY = 10;

        public static class Keyboard;
        public Protagonist[] team;
        public Inventory inventory;
        //save

        public void Input()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Z:
                        Move(MoveDirection.Forward);
                        break;
                    case ConsoleKey.S:
                        Move(MoveDirection.Backward);
                        break;
                    case ConsoleKey.Q:
                        Move(MoveDirection.Left);
                        break;
                    case ConsoleKey.D:
                        Move(MoveDirection.Right);
                        break;
                    default:
                        continue;
                }

            } while (true);
        }
        private void Move(MoveDirection direction)
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(" ");

            switch (direction)
            {
                case MoveDirection.Forward:
                    playerY--;
                    break;
                case MoveDirection.Backward:
                    playerY++;
                    break;
                case MoveDirection.Left:
                    playerX--;
                    break;
                case MoveDirection.Right:
                    playerX++;
                    break;
            }

            DrawPlayer();
        }
        public void DrawPlayer()
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write("P");
        }
    }

}
