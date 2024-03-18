using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    struct Inventory
    {
        int golds;
        int soulTokens;
    }


    internal class Player
    {
        public Protagonist[] team;
        public Inventory inventory;
        //save
    }
}
