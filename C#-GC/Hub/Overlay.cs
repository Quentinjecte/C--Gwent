using C__GC.Combats;
using C__GC.DataString;
using C__GC.Entity;

using Microsoft.VisualBasic.FileIO;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace C__GC.Hub
{
    internal class Overlay
    {
        Hub hub = new();
        Player.Player Player = new();
        DisplayElement DisplayE;

        private int _OlverlayIndex,
            isClosed,
            _boxX,
            _boxY,
            boxWidth,
            boxHeight;

        private bool InFight = false;

        private Rectangle Box;

        public str_func[] _OverlayOptions;
        public str_func[] _OverlayFight;

        public Overlay()
        {

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
                new str_func("      Attack      ", (author, target) => author.attack(target), 0),
                new str_func("      Spell       "),
                new str_func("      Item        "),
            };

            if (InFight)
            {
                _boxX = 4;
                _boxY = 2;
                boxWidth = 10;
                boxHeight = 10;
                Box = new Rectangle(_boxX + 5, _boxY, boxWidth - 20, boxHeight);
            }
            else
            {
                _boxX = 0;
                _boxY = 0;
                boxWidth = 20;
                boxHeight = 20;

                Box = new Rectangle(2, 2, 20, 10);
            }

        }
        public void InitPopUp(str_func[] OlInfo, int x, int y)
        {
            _boxX = x;
            _boxY = y;
            _OlverlayIndex = 0;
            _OverlayOptions = OlInfo;
            MenuPopUp();
            PrintText(_OverlayOptions);
            DisplaySystem.Unsubscribe();
            DisplaySystem.Update();
        }
        private void MenuPopUp()
        {
            DisplayE = new DisplayElement(CharactereData.OverlayMenu, 240, _boxX, _boxY);

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
            int textX = _boxX;
            int textY = _boxY + 1;

            for (int i = 0; i < _OverlayOptions.Length; i++)
            {
                string CurrentOption = _OverlayOptions[i].Str;

                DisplayElement element = new DisplayElement(CurrentOption, CurrentOption.Length, textX, textY);
                if (i == _OlverlayIndex)
                {
                    element.fgColor = ConsoleColor.Red;
                }
                else
                {
                    element.fgColor = ConsoleColor.White;
                    element.bgColor = ConsoleColor.Black;
                }
                DisplaySystem.Subscribe(element);
                textY++;
                //Change les chars en ' '
                if (_OverlayOptions[i].Str.Trim() == "Exit")
                {
                    while (textY <= Box.Bottom - 1)
                    {

                        DisplayElement emptyElement = new DisplayElement(new string(' ', Box.Width - 2), CurrentOption.Length, textX, textY);
                        textY++;
                    }
                }
            }
            DisplaySystem.Update();
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
