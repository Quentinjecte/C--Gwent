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
        //MapParser MapParser = new();
        Hub.Hub hub = new();
        Player Player = new();
        DisplayElement DisplayE;

        private int _OlverlayIndex, 
            isClosed, 
            boxX,
            boxY, 
            consoleWidth, 
            consoleHeight, 
            boxWidth, 
            boxHeight;

        private char BoxBoder = '█';
        private bool InFight = false;

        private Rectangle Box;
        private List<string> MapStringSave;

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
                new str_func("      Attack      ", (Character author, Character target) => author.attack(target), 0),
                new str_func("      Spell       "),
                new str_func("      Item        "),
            };

            consoleWidth = Console.WindowWidth;
            consoleHeight = Console.WindowHeight;


/*            if (InFight)
            {
                Box = new Rectangle(boxX + 5, boxY, boxWidth - 20, boxHeight);
            boxX = 4;
            boxY = 2;
            boxWidth = 10;
            boxHeight = 10;            
            }*/

            boxX = 3;
            boxY = 3;
            boxWidth = 20;
            boxHeight = 20;

            Box = new Rectangle(2, 2, 20, 20);
        }
        public void InitPopUp(str_func[] OlInfo)
        {
            _OlverlayIndex = 0;
            _OverlayOptions = OlInfo;
            MenuPopUp();
            PrintText(_OverlayOptions);
            Console.SetCursorPosition(2, 26);
            DisplaySystem.Unsubscribe();
            DisplaySystem.Update();
        }
        private void MenuPopUp()
        {
            DisplayElement displayElement = DisplayE;

            for (int i = Box.Y; i <= Box.Bottom; i++)
            {
                Console.SetCursorPosition(Box.X, i);
                for (int j = Box.X; j < Box.Right + 1; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(BoxBoder);
                }
            }
            DisplayE = new DisplayElement(BoxBoder.ToString(), 20, 2, 18);
            DisplaySystem.Subscribe(DisplayE);
            DisplaySystem.Update();
        }
        private void PrintText(str_func[] OlInfo)
        {
            SwapIndex();
        }
        private void OverlayIG()
        {
            //Change la couleur de la police
            int textX = boxX;
            int textY = boxY;

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
                // temporary way to close the popup
                isClosed = 1;

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
