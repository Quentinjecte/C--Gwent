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

        MapParser Parser = new();

        public int playerX = 10;
        public int playerY = 10;

        public Protagonist[] team;
        public Inventory inventory;

        //saveS
        public void Input(Bitmap img, int x, int y)
        {
            ConsoleKeyInfo keyInfo;
            Overlay overlay = new Overlay();
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
                    case ConsoleKey.P: 
                        overlay.InitPopUp(overlay._OverlayOptions, img);
                        if(keyInfo.Key == ConsoleKey.P)
                        {
                            Console.Clear();
                            string assetsPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "B:\\repos\\C--Gwent\\C#-GC\\assets\\testMap.bmp");
                            Bitmap mapImage = Parser.Load(assetsPath);
                            Console.WriteLine(Parser.ParseBitmap(assetsPath, 100));
                        }
                        break;
                    default:
                        continue;
                }
                Move(img, x, y);
                OverlayOnCase(img, playerX, playerY, x, y);

            } while (true);
        }
        private void Move(Bitmap img, int x, int y)
        {
            int newX = playerX + x;
            int newY = playerY + y;

            if (Parser.GetCollision(img, newX, newY) == false)
            {
                playerX = newX;
                playerY = newY;
                Console.SetCursorPosition(playerX, playerY);
                DrawPlayer();
            }
        }
        public void DrawPlayer()
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write("P");
        }

        private void OverlayOnCase(Bitmap img, int playerX, int playerY, int dx, int dy)
        {

            int leftX = playerX - dx;
            int leftY = playerY - dy;
            int rightX = playerX + dx;
            int rightY = playerY + dy;

            // Retrieve the characters from the GetCharacter method
            char leftCharacter = Parser.GetWalkingArea(img, leftX, leftY);
            char rightCharacter = Parser.GetWalkingArea(img, rightX, rightY);

            // Print the characters at the calculated positions
            Console.SetCursorPosition(leftX, leftY);
            Console.Write(leftCharacter);
            Console.SetCursorPosition(rightX, rightY);
            Console.Write(rightCharacter);
        }
    }

}