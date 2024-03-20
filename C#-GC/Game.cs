using Microsoft.VisualBasic.FileIO;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
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
            
            int HubIndex = MainHub.SwapIndex();

            ProgramTest.Save();
            //int Volume = MainHub.Volume;

           //switch (HubIndex)
           // {
           //     case 0:
           //         MainHub.NewGame();
           //         break;

           //     case 1:
           //         MainHub.Continue();
           //         break;

           //     case 2:
           //         MainHub.Option(prompt);
           //         StartHub();
           //         break;

           //     case 3:
           //         MainHub.Credit();
           //         StartHub();
           //         break;

           //     case 4:
           //         MainHub.Exit();
           //         break;
           // }
        }
    }
}
