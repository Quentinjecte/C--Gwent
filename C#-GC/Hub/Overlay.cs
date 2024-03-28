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
        Player Player = new();
        DisplayElement DisplayE;
        DisplayElement element;

        private int _OlverlayIndex,
            isClosed,
            _boxX,
            _boxY,
            boxWidth,
            boxHeight;

        public static bool InFight;

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
                _boxX = 20;
                _boxY = 20;
                boxWidth = Console.WindowWidth - 25;
                boxHeight = Console.BufferHeight;
                Box = new Rectangle(_boxX + 5, _boxY, boxWidth - 20, boxHeight);
            }
            else
            {
                _boxX = 2;
                _boxY = 2;
                boxWidth = 20;
                boxHeight = 20;
                Box = new Rectangle(2, 2, 20, 10);
            }
        }

        public void InitPopUp(str_func[] OlInfo, int x, int y, bool backGround = false)
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
            if (InFight)
            {
                _boxX = 20;
                _boxY = 20;
                DisplayE = new DisplayElement(CharactereData.OverlayFight, 156, _boxX, _boxY);
            }
            else
            {
                DisplayE = new DisplayElement(CharactereData.OverlayMenu, 20, _boxX, _boxY);
            }

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
            int textX = _boxX + 1;
            int textY = _boxY + 1;

            for (int i = 0; i < _OverlayOptions.Length; i++)
            {
                string CurrentOption = _OverlayOptions[i].Str;

                element = new DisplayElement(CurrentOption, CurrentOption.Length, textX, textY);
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
                    else if (KeyPress == ConsoleKey.P || KeyPress == ConsoleKey.Escape)
                    {
                        isClosed = 1;
                        for (int i = 0; i < _OverlayOptions.Length; i++)
                            DisplaySystem.Unsubscribe();
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
