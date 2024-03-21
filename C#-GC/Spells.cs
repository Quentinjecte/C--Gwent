using NAudio.Dmo.Effect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
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

        public Action<Character> effect;

        public Spell(string name, Type type, Action<Character> eff, int dmg = 0) 
        { 
            _dmg = dmg;
            _name = name;
            _type = type;
            effect = eff;
        }

        public void Cast(Character target)
        {
            target.TakeDmg(_dmg);
            effect?.Invoke(target);
        }
    }

    static public class SpellCollection
    {
        static public Spell testSpell = new Spell("test", Spell.Type.demonic, (Character) => { }, 20);
    }
}
