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

        List<string> content = new List<string>
        {
            "This is line 1",
            "This is line 2",
            "This is line 3"
        };
        public void InitPopUp()
        {
            MenuPopUp();
            PrintText(content);
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
        private void PrintText(List<string> lines)
        {
            // Adjust position for the text inside the box
            int textX = Box.X + 1; 
            int textY = Box.Y + 1;

            foreach (string line in lines)
            {
                Console.SetCursorPosition(textX, textY);
                Console.WriteLine(line);
                textY++;
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
