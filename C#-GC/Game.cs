using C__GC.DataString;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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

            int HubIndex = MainHub.SwapIndex();

        }
    }
}
