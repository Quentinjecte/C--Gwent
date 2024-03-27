using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
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

        static public void Update()
        {
            foreach (DisplayElement element in _elements) 
            {
                Console.ForegroundColor = element.fgColor;
                Console.BackgroundColor = element.bgColor;
                int height = element.content.Length / element.width;
                if (element.alpha)
                {
                    for (int i = 0; i < height; i++)
                    {
                        string subElement = element.content.Substring(i * element.width, element.width);
                        for(int j=0; j<subElement.Length; j++)
                        {
                            if (subElement[j] != ' ')
                            {
                                Console.SetCursorPosition(element.xOffset + j, element.yOffset + i * element.width);
                                Console.Write(subElement[j]);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < height; i++)
                    {
                        Console.SetCursorPosition(element.xOffset, element.yOffset + i);
                        Console.Write(element.content.Substring(i * element.width, element.width));
                    }
                }
            }
        }

        static public void Subscribe(DisplayElement element)
        {
            _elements.Add(element);
        }
        static public void Unsubscribe()
        {
            _elements.Remove(_elements.Last<DisplayElement>());
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
            if(index != -1)
            {
                _elements[index] = newValue;
            }
        }
    }
}
