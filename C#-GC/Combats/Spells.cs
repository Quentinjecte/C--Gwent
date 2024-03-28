using C__GC.Entity;
using NAudio.Dmo.Effect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC.Combats
{
    public class Spell
    {
        public enum Type
        {
            demonic,
            holy,
            sanity,
            shadow
        }

        public string _name;
        public Type _type;
        public int _dmg;
        public int _manaCost;

        public Action<Character> Effect;

        public Spell(string name, int manaCost, Type type, Action<Character> eff, int dmg = 0)
        {
            _manaCost = manaCost;
            _name = name;
            _type = type;
            Effect = eff;
            _dmg = dmg;
        }

        public void Cast(Character target)
        {
            target.TakeDmg(_dmg);
            Effect.Invoke(target);
        }
    }

    static public class SpellCollection
    {
        static public Spell BurningHand = new Spell("Burning Hand", 20, Spell.Type.demonic, (target) => { Status.Subscribe(() => { Status.Burn(target); }); });
    }
}
