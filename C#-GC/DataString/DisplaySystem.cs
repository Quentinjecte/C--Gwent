using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__GC.DataString
{
    public struct DisplayElement(
        string CONTENT,
        int WIDTH,
        int XOFFSET,
        int YOFFSET,
        ConsoleColor FGCOLOR = ConsoleColor.White,
        ConsoleColor BGCOLOR = ConsoleColor.Black,
        bool ALPHA = false)
    {
        public string content = CONTENT;
        public int width = WIDTH;
        public int xOffset = XOFFSET;
        public int yOffset = YOFFSET;
        public ConsoleColor fgColor = FGCOLOR;
        public ConsoleColor bgColor = BGCOLOR;
        public bool alpha = ALPHA;
    }
    static class DisplaySystem
    {
        static public List<DisplayElement> _elements = new List<DisplayElement>();

        static public void Update(bool clear = false)
        {
            if (clear)
            {
                Console.Clear();
            }
            //PrintMap();
            foreach (DisplayElement element in _elements)
            //for (int e = 1; e < _elements.Count; e++)
            {
                //DisplayElement element = _elements[e];
                Console.ForegroundColor = element.fgColor;
                Console.BackgroundColor = element.bgColor;

                if(element.width > 0)
                {
                    int height = element.content.Length / element.width;
                    //if (element.alpha)
                    //{
                    //    for (int i = 0; i < height; i++)
                    //    {
                    //        string subElement = element.content.Substring(i * element.width, element.width);
                    //        for (int j = 0; j < subElement.Length; j++)
                    //        {
                    //            if (subElement[j] != ' ')
                    //            {
                    //                Console.SetCursorPosition(element.xOffset + j, element.yOffset + i * element.width);
                    //                Console.Write(subElement[j]);
                    //            }
                    //        }
                    //    }
                    //}
                    //else
                    {
                        for (int i = 0; i < height; i++)
                        {
                            Console.SetCursorPosition(element.xOffset, element.yOffset + i);
                            Console.Write(element.content.Substring(i * element.width, element.width));
                        }
                    }
                }
                else
                {
                    int count = 1;
                    int currX = element.xOffset;
                    int currY = element.yOffset;
                    Console.SetCursorPosition(element.xOffset, element.yOffset);
                    for (int i = 0; i < element.content.Length; i++)
                    {
                        if (element.content[i] == '\n')
                        {
                            currX = element.xOffset;
                            currY = element.yOffset + count;
                            count++;
                        }
                        else
                        {
                            Console.SetCursorPosition(currX, currY);
                            Console.Write(element.content[i]);
                        }

                        if (element.content[i] == '\x1b')
                        {
                            currX++;
                        }
                    }

                }
            }
                
        }

        static public void PrintMap()
        {
            DisplayElement element = _elements[0];
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(element.content);
            //int count = 1;
            //int currX = element.xOffset;
            //int currY = element.yOffset;
            //Console.SetCursorPosition(element.xOffset, element.yOffset);
            //for (int i = 0; i < element.content.Length; i++)
            //{
            //    if (element.content[i] == '\n')
            //    {
            //        currX = element.xOffset;
            //        currY = element.yOffset + count;
            //        count++;
            //    }
            //    else
            //    {
            //        Console.SetCursorPosition(currX, currY);
            //        Console.Write(element.content[i]);
            //    }

            //    if (element.content[i] == '\x1b')
            //    {
            //        currX++;
            //    }
            //}
        }

        static public void Subscribe(DisplayElement element)
        {
            _elements.Add(element);
        }
        static public void Unsubscribe()
        {
            _elements.Remove(_elements.Last());
        }
        static public void Unsubscribe(DisplayElement element)
        {
            if (_elements.Contains(element))
            {
                _elements.Remove(element);
            }
        }
        static public void Clear()
        {
            _elements.Clear();
        }
        static public void ReplaceByIndex(int index, DisplayElement element)
        {
            _elements[index] = element;
        }
        static public void ReplaceByValue(DisplayElement value, DisplayElement newValue)
        {
            int index = _elements.IndexOf(value);
            if (index != -1)
            {
                _elements[index] = newValue;
            }
        }
        static public DisplayElement GetById(int id)
        {
            return _elements[id];
        }
    }
}
