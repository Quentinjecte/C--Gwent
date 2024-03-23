using C__GC.DataString;
using Microsoft.VisualBasic.FileIO;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    internal class Overlay
    {
        MapParser MapParser = new();

        private int _OlverlayIndex;
        private int isClosed;

        private char BoxBoder = '█';
        private bool InFight = true;
        private char MapCharSaveX;
        private char MapCharSaveY;

        private Rectangle Box;
        private List<string> MapStringSave;

        str_func[] OlInfo;
        public str_func[] _OverlayOptions;
        public str_func[] _OverlayFight;
        
        public Overlay()
        {
            MapStringSave = new List<string>();
            _OverlayOptions = new[] {
                new str_func("     Continue     "),
                new str_func("       Stat       "),
                new str_func("       Item       "),
                new str_func("      Option      "),
                new str_func("       Save       "),
                new str_func("       Load       "),
                new str_func("       Exit       "),
            };
            _OverlayFight = new[] {// Update to do
                new str_func("     Continue     "),
                new str_func("       Stat       "),
                new str_func("       Item       "),
                new str_func("      Option      "),
                new str_func("       Save       "),
                new str_func("       Load       "),
                new str_func("       Exit       "),
            };
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;
            int boxX = 5;
            int boxY = consoleHeight - 25;
            int boxWidth = consoleWidth - 5;
            int boxHeight = 10;

            if (InFight)
            {
                Box = new Rectangle(boxX + 5, boxY, boxWidth - 20, boxHeight);
            }
            else Box = new Rectangle(2, 2, 20, 20);
        }
        public void InitPopUp(str_func[] OlInfo, Bitmap img)
        {
            _OlverlayIndex = 0;
            _OverlayOptions = OlInfo;
            MenuPopUp(img);
            PrintText(_OverlayOptions);
            Console.SetCursorPosition(2, 26);
            foreach (string aPart in MapStringSave)
            {
                Console.Write(aPart);
            }
        }
        /*private void SaveMapage()
        {

        }*/
        private void MenuPopUp(Bitmap img)
        {
            //Save Map en cour
            for (int i = Box.Y; i <= Box.Bottom; i++)
            {
                Console.SetCursorPosition(Box.X, i);
                Console.Write(BoxBoder);
                for (int j = Box.X; j < Box.Right; j++)
                {
                    /*                    Console.SetCursorPosition(j, i);
                                        MapCharSaveY = MapParser.GetWalkingArea(img, i, j);
                                        MapStringSave.Add(MapCharSaveY);
                                        MapStringSave = MapParser.ParseBitmap(this,this);*/
                }
                //MapStringSave.Add(MapCharSaveY);
            }

            if (false == InFight)
            {
                for (int i = Box.Y; i <= Box.Bottom; i++)
                {
                    Console.SetCursorPosition(Box.X, i);
                    for (int j = Box.X; j < Box.Right; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(BoxBoder);
                    }
                }
            }
            else
            {
                for (int i = Box.Y; i <= Box.Bottom; i++)
                {
                    Console.SetCursorPosition(Box.X, i);
                    Console.Write(BoxBoder);
                    Console.SetCursorPosition(Box.Right, i);
                    Console.Write(BoxBoder);
                }

                for (int i = Box.X; i <= Box.Right; i++)
                {
                    Console.SetCursorPosition(i, Box.Y);
                    Console.Write(BoxBoder);
                    Console.SetCursorPosition(i, Box.Bottom);
                    Console.Write(BoxBoder);
                }
            }
        }
        private void PrintText(str_func[] OlInfo)
        {
            SwapIndex();
        }
        private void OverlayIG()
        {
            //Change la couleur de la police
            int textX = Box.X + 1;
            int textY = Box.Y + 1;

            for (int i = 0; i < _OverlayOptions.Length; i++)
            {
                string CurrentOption = _OverlayOptions[i].Str;

                if (i == _OlverlayIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.SetCursorPosition(textX, textY);
                Console.WriteLine($"{CurrentOption}");
                textY++;
                //Change les chars en ' '
                if (_OverlayOptions[i].Str.Trim() == "Exit")
                {
                    while (textY <= Box.Bottom -1)
                    {
                        Console.SetCursorPosition(textX, textY);
                        Console.WriteLine(new string(' ', Box.Width - 2));
                        textY++;
                    }
                }
            }
            Console.ResetColor();
        }
        public int SwapIndex()
        {
            ConsoleKey KeyPress;

            do
            {
                do
                {
                    OverlayIG();

                    ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
                    KeyPress = KeyInfo.Key;

                    if (KeyPress == ConsoleKey.UpArrow)
                    {
                        _OlverlayIndex--;
                        if (_OlverlayIndex == -1)
                        {
                            _OlverlayIndex = _OverlayOptions.Length - 1;
                        }
                    }
                    else if (KeyPress == ConsoleKey.DownArrow)
                    {
                        _OlverlayIndex++;
                        if (_OlverlayIndex == _OverlayOptions.Length)
                        {
                            _OlverlayIndex = 0;
                        }
                    }
                    else if (KeyPress == ConsoleKey.P)
                    {
                        isClosed = 1;
                        break;
                    }
                } while (KeyPress != ConsoleKey.Spacebar);

                _OverlayOptions[_OlverlayIndex].ExecuteAction();

            } while (isClosed != 1);

            return _OlverlayIndex;
        }
    }

    public class Rectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int Right => X + Width - 1;
        public int Bottom => Y + Height - 1;
    }
}
