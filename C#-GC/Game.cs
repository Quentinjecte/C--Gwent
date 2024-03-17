using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    internal class Game
    {
        public void Start()
        {
            string prompt = @"

      ░▒▓██████▓▒░  ░▒▓█▓▒░         ░▒▓██████▓▒░   ░▒▓███████▓▒░ ░▒▓████████▓▒░ ░▒▓███████▓▒░  ░▒▓████████▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓████████▓▒░  ░▒▓███████▓▒░ 
     ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        
     ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        
     ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓██████▓▒░  ░▒▓██████▓▒░   ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓██████▓▒░    ░▒▓██████▓▒░  ░▒▓██████▓▒░    ░▒▓██████▓▒░  
     ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░        ░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░           ░▒▓█▓▒░     ░▒▓█▓▒░               ░▒▓█▓▒░ 
     ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░        ░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░           ░▒▓█▓▒░     ░▒▓█▓▒░               ░▒▓█▓▒░ 
      ░▒▓██████▓▒░  ░▒▓████████▓▒░  ░▒▓██████▓▒░  ░▒▓███████▓▒░  ░▒▓████████▓▒░ ░▒▓███████▓▒░  ░▒▓████████▓▒░    ░▒▓█▓▒░     ░▒▓████████▓▒░ ░▒▓███████▓▒░  

Use arrow keys and press 'Spacebar' for select ur options ";

            string[] options = { "New Game", "Continue", "Options", "Credits", "Exit" };

            Hub MainHub = new Hub(prompt, options);

            int HubIndex = MainHub.SwapIndex();

           switch (HubIndex)
            {
                case 0:
                    MainHub.NewGame();
                    break;

                case 1:
                    MainHub.Continue();
                    break;

                case 2:
                    MainHub.Option();
                    break;

                case 3:
                    MainHub.Credit();
                    break;

                case 4:
                    MainHub.Exit();
                    break;
            }
        }
    }
}
