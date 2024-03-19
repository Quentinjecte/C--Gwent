using Microsoft.VisualBasic.FileIO;
using System;
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

            

            Hub MainHub = new Hub();
            str_func[] HubInfo = [
                new str_func("New Game", MainHub.NewGame),
                new str_func("Continue", MainHub.Continue),
                new str_func("Options", MainHub.Option),
                new str_func("Credits", MainHub.Credit),
                new str_func("Exit", MainHub.Exit)
                ];
            MainHub.InitHub(prompt, HubInfo);
            
            int HubIndex = MainHub.SwapIndex(0);
            int Volume = MainHub.Volume;

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
