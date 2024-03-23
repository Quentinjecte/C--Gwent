using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__GC.Items
{
    public struct ItemType
    {
        public  int Heal;
        public  int Mana;
        public int AtkBonus;
        public int Effect;
    }
    internal class Item
    {
        public string _name { get; set; }
        public int _value { get; set; }  // Price or rarity ?
        public ItemType _effect { get; set; } // Types and values (ex : heal 10hp, hit 10hp)


        public Item(string name, int value, ItemType effect) 
        {
            _name = name;
            _value = value;
            _effect = effect;
        }

        public virtual void Use(Character character)
        {
            Console.WriteLine($"You used {_name}!");

            character.Stats.atk += _effect.AtkBonus;
            character.Stats.hp += _effect.Heal;
            character.Stats.mana += _effect.Mana;

            Console.WriteLine($"Item effects applied to character: ATK +{_effect.AtkBonus}, HP +{_effect.Heal}, Mana +{_effect.Mana}");
        }


    }
}
