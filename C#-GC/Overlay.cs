using C__GC.DataString;
using Microsoft.VisualBasic.FileIO;
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
        private int _OlIndex;
        private int isClosed;

        private const char DefaultBoxBorder = '█';
        private Rectangle Box = new Rectangle(5,5,20,20);
        private char BoxBoder = DefaultBoxBorder;

        str_func[] OlInfo;
        public str_func[] _OlOptions;

        public Overlay()
        {
            _OlOptions = new[] {
                new str_func("     Continue     "),
                new str_func("       Stat       "),
                new str_func("       Item       "),
                new str_func("      Option      "),
                new str_func("       Save       "),
                new str_func("       Load       "),
                new str_func("       Exit       "),
            };
        }
        public void InitPopUp(str_func[] OlInfo)
        {
            _OlIndex = 0;
            _OlOptions = OlInfo;
            MenuPopUp();
            PrintText(_OlOptions);
        }
        private void MenuPopUp()
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
        private void PrintText(str_func[] OlInfo)
        {
            SwapIndex();
        }
        private void OverlayIG()
        {
            int textX = Box.X + 1;
            int textY = Box.Y + 1;

            for (int i = 0; i < _OlOptions.Length; i++)
            {
                string CurrentOption = _OlOptions[i].Str;

                if (i == _OlIndex)
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
                if (_OlOptions[i].Str.Trim() == "Exit")
                {
                    while (textY <= Box.Bottom -1)
                    {
                        Console.SetCursorPosition(textX, textY);
                        Console.WriteLine(new string(' ', Box.Width - 2)); // Remplir avec des espaces
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
                        _OlIndex--;
                        if (_OlIndex == -1)
                        {
                            _OlIndex = _OlOptions.Length - 1;
                        }
                    }
                    else if (KeyPress == ConsoleKey.DownArrow)
                    {
                        _OlIndex++;
                        if (_OlIndex == _OlOptions.Length)
                        {
                            _OlIndex = 0;
                        }
                    }
                    else if (KeyPress == ConsoleKey.P)
                    {
                        isClosed = 1;
                        break;
                    }
                } while (KeyPress != ConsoleKey.Spacebar);

                _OlOptions[_OlIndex].ExecuteAction();

            } while (isClosed != 1);

            return _OlIndex;
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
