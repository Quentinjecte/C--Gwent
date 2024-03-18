using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    struct Stats
    {
        int atk;
        int hp;
        int mana;
    }


    internal class  Offense
    {
        public int dmg;

        public virtual void effect() { }
    }


    internal class Spell
    {
        enum Type
        {
            demonic,
            holy,
            sanity,
            shadow
        }

        public int dmg;
        public int type;

        public virtual void effect() { }
    }


    public class Character
    {
        Stats stats;
        string name;
        Offense[] offenses;
        Spell[] spells;
    }
}
