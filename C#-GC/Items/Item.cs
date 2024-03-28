using C__GC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__GC.Combats
{
    public class Item
    {
        public enum ItemType
        {
            heal,
            mana,
            atkBonus,
            effect // diff than _effect this one is about poison etc 
        }
        public string _name;
        public ItemType _effect;
        public int _value;
        public int _dmg;
        public int _mana;


        public Item(string name, int value, ItemType effect, Action<Character> eff, int dmg = 0)
        {
            _name = name;
            _value = value;
            _effect = effect;
            _dmg = dmg;
        }

        public virtual void Use(Character target)
        {
            Console.WriteLine($"You used {_name}!");

            target.TakeDmg(_dmg);
            target.ApplyAttackBonus(_dmg);
            target.RestoreMana(_mana);

        }

    }
            static public class ItemCollection
        {
            static public Item HealPotion = new Item("Heal Potion", 20, Item.ItemType.heal, (target) => { Status.Subscribe(() => { Status.Heal(target); }); });
            static public Item testItemM = new Item("Mana Potion", 30, Item.ItemType.mana, (target) => { Status.Subscribe(() => { Status.RestoreManaTarget(target); }); });
            static public Item testItemAB = new Item("Attack Bonus Potion", 40, Item.ItemType.atkBonus, (target) => { Status.Subscribe(() => { Status.AttackBonus(target); }); });
            static public Item testItemE = new Item("Poison Potion", 50, Item.ItemType.effect, (target) => { Status.Subscribe(() => { Status.Poison(target); }); });

    }
}