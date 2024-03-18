using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        MapParser mapParser = new MapParser();
        Bitmap img;
        public int playerX = 0;
        public int playerY = 0;

        public static class Keyboard;
        public Protagonist[] team;
        public Inventory inventory;

        public int asciiWidth { get; private set; }
        public int asciiHeight { get; private set; }

        //saveS
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
                InteractWithMap(img);

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

        public void InteractWithMap(Bitmap mapImage)
        {
            // Update the player's position on the map
            char mapCharacter = mapParser.GetMapAtCoordinates(mapImage, playerX, playerY);
            Console.WriteLine(mapCharacter);
        }
    }

}