using C__GC.DataString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    internal class Dialogue
    {
        DisplayElement renderer;
        public void Read()
        {
            renderer = new DisplayElement("Bien le bonjour c'est jerem", 15, 0, 0);

            DisplaySystem.Subscribe(renderer);
        }


    }
}
