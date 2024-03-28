/*using C__GC.Entity;
using C__GC.Combats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__GC
{
    internal class AtkBonus : Item
    {

        public override void Use(Character character)
        {
            base.Use(character);
            Console.WriteLine($"You used {_name}! It gives {character} a bonus of {_atkbonus} Attack !");
            character.ApplyAttackBonus(_atkbonus);
        }

        private static class ATKBonuses
        {
            public static AtkBonus TaperPotion { get; } = new AtkBonus("TAPER Potion", 5, 3);
            public static AtkBonus TaperFortPotion { get; } = new AtkBonus("TAPER FORT Potion", 5, 6);
            public static AtkBonus TaperTresFortPotion { get; } = new AtkBonus("TAPER TRES FORT Potion", 5, 10);
        }
    }
}*/