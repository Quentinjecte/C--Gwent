using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    internal class Overlay
    {
        private const char DefaultBoxBorder = '█';
        private Rectangle Box = new Rectangle(2,2,20,20);
        private char BoxBoder = DefaultBoxBorder;

        public void InitPopUp()
        {
            MenuPopUp();
        }

        private void MenuPopUp()
        {
            for (int i = Box.Y;i <= Box.Height;i++) 
            {
                Console.SetCursorPosition(Box.X, i);
                Console.Write(BoxBoder);
                Console.SetCursorPosition(Box.Right, i);
                Console.Write(BoxBoder);
                Console.SetCursorPosition(i, Box.Y);
                Console.Write(BoxBoder);
                Console.SetCursorPosition(i, Box.Bottom);
                Console.Write(BoxBoder);
            }

            for (int i = Box.X;i <= Box.Right;i++) 
            {
                Console.SetCursorPosition(Box.X, i);
                Console.Write(BoxBoder);
                Console.SetCursorPosition(Box.Right, i);
                Console.Write(BoxBoder);
                Console.SetCursorPosition(i, Box.Y);
                Console.Write(BoxBoder);
                Console.SetCursorPosition(i, Box.Bottom);
                Console.Write(BoxBoder);
            }
        }
    }
}
