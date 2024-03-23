using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC.Items
{
    public enum ItemType
    {
        Consumable,
        Permanent
    }
    internal class Item
    {
        string _name;
        int _value;
        ItemType _type;


        public Item(string name, int value, ItemType type) 
        {
            _name = name;
            _value = value;
            _type = type;
        }

        public virtual void Use()
        {
        }


    }
}
