using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    static public class CharaClasses
    {
        static public List<Protagonist> classes = new List<Protagonist>()
        {
            //new Protagonist("mage", new Stats(10, 80, 150))
            new Protagonist("Fighter",   new Stats(10, 33, 7)),
            new Protagonist("Crusader",  new Stats(5, 29, 15)),
            new Protagonist("Priest",    new Stats(1, 20, 25)),
            new Protagonist("Arcanist",  new Stats(1, 15, 30)),
            new Protagonist("Rogue",     new Stats(6, 18, 12)),
        };

        static public Dictionary<string, Stats> lvlPackages = new Dictionary<string, Stats>
        {
            // { "mage 2", new Stats(0, 10, 15)}
            {"Fighter 2", new Stats(0, 7, 3) },
            {"Fighter 3", new Stats(1, 8, 2) },
            {"Fighter 4", new Stats(0, 7, 2) },
            {"Fighter 5", new Stats(1, 9, 1) },

            {"Crusader 2", new Stats(0, 6, 4) },
            {"Crusader 3", new Stats(1, 7, 3) },
            {"Crusader 4", new Stats(0, 5, 5) },
            {"Crusader 5", new Stats(1, 8, 2) },

            {"Priest 2", new Stats(0, 5, 5) },
            {"Priest 3", new Stats(0, 4, 6) },
            {"Priest 4", new Stats(0, 3, 7) },
            {"Priest 5", new Stats(1, 4, 6) },

            {"Arcanist 2", new Stats(0, 4, 6) },
            {"Arcanist 3", new Stats(0, 3, 7) },
            {"Arcanist 4", new Stats(0, 3, 7) },
            {"Arcanist 5", new Stats(1, 8, 2) },

            {"Rogue 2", new Stats(0, 6, 4) },
            {"Rogue 3", new Stats(1, 7, 3) },
            {"Rogue 4", new Stats(0, 5, 5) },
            {"Rogue 5", new Stats(1, 8, 2) },
        };
    }
}
