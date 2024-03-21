using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{

    public struct Inventory
    {
        int golds;
        int soulTokens;
    }


    public class Player
    {

        MapParser mapParser = new MapParser();
        public int playerX = 10;
        public int playerY = 10;

        public Protagonist[] team;
        public Inventory inventory;


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
                    case ConsoleKey.P:
                        SaveLoad saving = new SaveLoad();
                        saving.Save(this);
                        break;/*
                    case ConsoleKey.L:
                        SaveLoad loading = new SaveLoad();
                        Console.Clear();
                        loading.Load();
                        break;*/
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

            if (mapParser.GetCollision(img, newX, newY) == false)
            {
                playerX = newX;
                playerY = newY;
                Console.SetCursorPosition(playerX, playerY);
                DrawPlayer(playerX, playerY);
            }
        }
        public void DrawPlayer(int PosX, int PosY)
        {
            Console.SetCursorPosition(PosX, PosX);
            Console.Write("P");
        }

        private void OverlayOnCase(Bitmap img, int playerX, int playerY, int dx, int dy)
        {

            int leftX = playerX - dx;
            int leftY = playerY - dy;
            int rightX = playerX + dx;
            int rightY = playerY + dy;

            // Retrieve the characters from the GetCharacter method
            char leftCharacter = mapParser.GetWalkingArea(img, leftX, leftY);
            char rightCharacter = mapParser.GetWalkingArea(img, rightX, rightY);

            // Print the characters at the calculated positions
            Console.SetCursorPosition(leftX, leftY);
            Console.Write(leftCharacter);
            Console.SetCursorPosition(rightX, rightY);
            Console.Write(rightCharacter);
        }

    }

}