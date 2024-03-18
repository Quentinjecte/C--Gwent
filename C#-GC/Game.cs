﻿using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
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
            string prompt = @"
                                                                                                           ░▒▓██▓▒░         
      ░▒▓██████▓▒░  ░▒▓█▓▒░         ░▒▓██████▓▒░   ░▒▓███████▓▒░ ░▒▓████████▓▒░ ░▒▓███████▓▒░          ░▒▓██████████▓▒░         ░▒▓████████▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓████████▓▒░  ░▒▓███████▓▒░ 
     ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░     ░▒▓█▓▒░          ░▒▓█▓▒░     ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        
     ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░   ░▒▓█▓▒░     ░▒▒░     ░▒▓█▓▒░   ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        
     ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓██████▓▒░  ░▒▓██████▓▒░   ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░     ░▓██▓░     ░▒▓█▓▒░  ░▒▓██████▓▒░    ░▒▓██████▓▒░  ░▒▓██████▓▒░    ░▒▓██████▓▒░  
     ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░        ░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░   ░▒▓█▓▒░     ░▒▒░     ░▒▓█▓▒░   ░▒▓█▓▒░           ░▒▓█▓▒░     ░▒▓█▓▒░               ░▒▓█▓▒░ 
     ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░        ░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░     ░▒▓█▓▒░          ░▒▓█▓▒░     ░▒▓█▓▒░           ░▒▓█▓▒░     ░▒▓█▓▒░               ░▒▓█▓▒░ 
      ░▒▓██████▓▒░  ░▒▓████████▓▒░  ░▒▓██████▓▒░  ░▒▓███████▓▒░  ░▒▓████████▓▒░ ░▒▓███████▓▒░           ░▒▓█████████▓▒░         ░▒▓████████▓▒░    ░▒▓█▓▒░     ░▒▓████████▓▒░ ░▒▓███████▓▒░  
                                                                                                           ░▒▓██▓▒░

Use arrow keys and press 'Spacebar' for select ur options :
";

            string[] HubInfo = { "New Game", "Continue", "Options", "Credits", "Exit" };

            Hub MainHub = new Hub(prompt, HubInfo);

            int HubIndex = MainHub.SwapIndex();
            int Volume = MainHub.Volume;

           switch (HubIndex)
            {
                case 0:
                    MainHub.NewGame();
                    break;

                case 1:
                    MainHub.Continue();
                    break;

                case 2:
                    MainHub.Option(prompt);
                    StartHub();
                    break;

                case 3:
                    MainHub.Credit();
                    StartHub();
                    break;

                case 4:
                    MainHub.Exit();
                    break;
            }
        }
    }
}
