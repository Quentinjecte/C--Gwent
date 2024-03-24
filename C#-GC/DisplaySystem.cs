using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    public struct DisplayElement
    {
        public string content;
        public int width;
        public int xOffset;
        public int yOffset;
    }
    static class DisplaySystem
    {
        static List<DisplayElement> _elements = new List<DisplayElement>();

        static public void Update()
        {
            foreach (DisplayElement element in _elements) 
            { 
                int height = element.content.Length / element.width;
                for(int i = 0 ; i < height; i++)
                {
                    Console.SetCursorPosition(element.xOffset, element.yOffset + i);
                    Console.Write(element.content.Substring(i*element.width, element.width)) ;
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
            _elements[index] = newValue;
        }
    }
}
