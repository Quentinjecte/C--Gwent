using System;
using System.Xml.Linq;

namespace C__GC.Items
{
    internal class Heal : Item
    {
        private int _heal;

        public Heal(string name, int value, int healingAmount) : base(name, value, new ItemType { heal = healingAmount })
        {
            _heal = healingAmount;
        }

        public override void Use(Character character)
        {
            base.Use(character);
            Console.WriteLine($"You used {_name}! It healed {character} for {_heal} HP.");
            character.TakeDmg(-_heal);
        }

        internal static class HealPotions
        {
            // Define healing items
            public static Heal SmallHealingPotion { get; } = new Heal("Small Healing Potion", 10, 20);
            public static Heal NormalHealingPotion { get; } = new Heal("Normal Healing Potion", 20, 50);
            public static Heal LargeHealingPotion { get; } = new Heal("Large Healing Potion", 30, 100); // Damn huge celle la ;)
        }
    }
}
