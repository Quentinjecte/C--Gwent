﻿using C__GC.DataString;
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
        private const char DefaultBoxBorder = '█';
        private Rectangle Box = new Rectangle(2,2,20,20);
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
            int textX = Box.X + 1; 
            int textY = Box.Y + 1;

            foreach (str_func option in OlInfo)
            {
                Console.SetCursorPosition(textX, textY);
                Console.WriteLine(option.Str);
                textY++;
                if (option.Str.Trim() == "Exit")
                {
                    while (textY <= Box.Bottom)
                    {
                        Console.SetCursorPosition(textX, textY);
                        Console.WriteLine(new string(' ', Box.Width - 2)); // Remplir avec des espaces
                        textY++;
                    }
                    break;
                }
            }
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
