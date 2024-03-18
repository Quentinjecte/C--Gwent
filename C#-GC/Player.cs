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

        public int playerX = 0;
        public int playerY = 0;


        public static class Keyboard;
        public Protagonist[] team;
        public Inventory inventory;
        //save

        public void Input()
        {
            MoveDirection moveDirection;

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Z:
                        moveDirection = MoveDirection.Forward;
                        break;
                    case ConsoleKey.S:
                        moveDirection = MoveDirection.Backward;
                        break;
                    case ConsoleKey.Q:
                        moveDirection = MoveDirection.Left;
                        break;
                    case ConsoleKey.D:
                        moveDirection = MoveDirection.Right;
                        break;
                    default:
                        continue;
                }

                Move(moveDirection);

            } while (true);
        }
        private void Move(MoveDirection direction)
        {
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
        }
    }
}
