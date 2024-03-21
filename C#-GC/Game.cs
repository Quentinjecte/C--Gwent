using Microsoft.VisualBasic.FileIO;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using C__GC.DataString;

namespace C__GC
{
    class Game
    {

        public void Start() 
        {
            Console.Title = "Closed-Eyes 👁";
            StartHub();
            
        }

        public void StartHub()
        {
            Hub.Hub MainHub = new Hub.Hub();

            MainHub.InitHub(CharactereData.Prompt, MainHub._mainMenuPreset);
            
             MainHub.SwapIndex();
        }
    }
}
