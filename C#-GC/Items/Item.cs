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
        public  int heal;
        public  int mana;
        public int atkBonus;
        public int effect; // diff than _effect this one is about poison etc 
    }
    internal class Item
    {
        public string _name { get; set; }
        public int _value { get; set; }  // Price or rarity ?
        public ItemType _effect { get; set; } // Types and values (ex : heal 10hp, hitBonus 10)


        public Item(string name, int value, ItemType effect) 
        {
            _name = name;
            _value = value;
            _effect = effect;
        }

        public virtual void Use(Character character)
        {
            Console.WriteLine($"You used {_name}!");

            character.TakeDmg(_effect.heal);
            character.ApplyAttackBonus(_effect.atkBonus);
            character.UseMana(_effect.mana);

        }


    }
}
