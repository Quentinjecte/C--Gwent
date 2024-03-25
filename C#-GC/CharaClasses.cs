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
            new Protagonist("mage", new Stats(10, 80, 150))
        };

        static public Dictionary<string, Stats> lvlPackages = new Dictionary<string, Stats>
        {
            { "mage 2", new Stats(0, 10, 15)}
        };
    }
}
