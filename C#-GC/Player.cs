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
        char _buffer;
        string _map;
        int _size;
        public int playerX = 10;
        public int playerY = 10;

        public Protagonist[] team;
        public Inventory inventory;

        public Player(string map, int size) 
        {
            _map = map;
            _size = size;
        }

        //saveS
        public void Input(Bitmap img, int x, int y)
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
                OverlayOnCase((playerX - x), ((playerY - y))*_size);
                ReplaceOldCase((playerX + x), ((playerY + y)) * _size);
                Move(img, x, y);

            } while (true);
        }
        private void Move(Bitmap img, int x, int y)
        {
            int newX = playerX + x;
            int newY = playerY + y;

                playerX = newX;
                playerY = newY;
            Console.SetCursorPosition(playerX, playerY);
            DrawPlayer();
        }
        public void DrawPlayer()
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write("P");
        }


        private bool OverlayOnCase(int PlayerX, int PlayerY)
        {
             _buffer = _map[PlayerX + PlayerY];
            return true;
        }

        private string ReplaceOldCase(int PlayerX, int PlayerY)
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(_buffer);
            return "";
        }
    }
}