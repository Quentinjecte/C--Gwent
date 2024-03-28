using NAudio.Dmo.Effect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
            necrotic,
            shadow,
            human
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
        static private int rdmStuff(int min, int max) { Random rnd = new Random(); return rnd.Next(min, max); }

        // static public Spell testSpell = new Spell("test", 20, Spell.Type.demonic, (Character target) => { Status.Subscribe(() => { Status.Burn(target); }); });
        static public Spell necrosisSpell =      new Spell("Necrosis", 2, Spell.Type.necrotic, null, rdmStuff(2, 7));
        static public Spell minorHealSpell =     new Spell("Minor Heal", 2, Spell.Type.holy, (Character target) => { target.Healed(rdmStuff(1, 6)); });
        static public Spell burningHandSpell =   new Spell("Burning Hand", 6, Spell.Type.demonic, (Character target) => { Status.Subscribe(() => { Status.Burn(target); }); }, rdmStuff(2, 12));
        static public Spell holyLightSpell =     new Spell("Holy Light", 2, Spell.Type.holy, (Character target) => { Status.Subscribe(() => { Status.Stun(target); }); }, rdmStuff(3, 8));
        static public Spell chargeSpell =        new Spell("Charge", 3, Spell.Type.human, (Character target) => { Status.Subscribe(() => { Status.Stun(target); }); }, rdmStuff(9, 16));
        static public Spell fearSpell =          new Spell("Fear", 4, Spell.Type.demonic, null, rdmStuff(1, 5));
        static public Spell toxicVaporSpell =    new Spell("Toxic Vapor", 2, Spell.Type.necrotic, (Character target) => { Status.Subscribe(() => { Status.Poison(target); }); }, rdmStuff(1, 4));
        static public Spell huntingTrapSpell =   new Spell("Hunting Trap", 5, Spell.Type.human, null, rdmStuff(3, 9));
        static public Spell curativPrayerSpell = new Spell("Curativ Prayer", 5, Spell.Type.holy, (Character target) => { target.Healed(rdmStuff(2, 8)); });
    }
}
