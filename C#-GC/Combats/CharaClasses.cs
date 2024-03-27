using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__GC.Entity;
using C__GC.Player;

namespace C__GC.Combats
{
    static public class CharaClasses
    {
        static public List<Protagonist> classes = new List<Protagonist>()
        {
            new Protagonist("mage", new Stats(10, 80, 150))
        };

        static public Dictionary<string, Stats> lvlPackages = new Dictionary<string, Stats>
        {
            { "mage 2", new Stats(0, 10, 15)}
        };
    }
}
