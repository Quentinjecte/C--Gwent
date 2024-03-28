/*using C__GC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__GC.Items
{
    internal class Mana : Item
    {
        private int _mana;
        public Mana(string name, int value, int manaGivenAmount) : base(name, value, new ItemType { mana = manaGivenAmount })
        {
            _mana = manaGivenAmount;
        }

        public override void Use(Character character)
        {
            base.Use(character);
            Console.WriteLine($"You used {_name}! It gives {character} a bonus of {_mana} Attack !");
            character.RestoreMana(_mana);
        }

        internal static class ManaPotions
        {
            // Define healing items
            public static Mana SmallManaPotion { get; } = new Mana("Small Mana Potion", 10, 20);
            public static Mana NormalManaPotion { get; } = new Mana("Normal Mana Potion", 20, 50);
            public static Mana LargeManaPotion { get; } = new Mana("Large Mana Potion", 30, 100); // Damn huge celle la ;)
        }
    }
}*/