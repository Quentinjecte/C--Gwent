using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC.Items
{
    internal class Mana : Item
    {
        public Mana(string name, int value) : base(name, value, ItemType.Mana)
        {
        }

        public override void Use()
        {
            Console.WriteLine($"Tu as utilisé {_name} ! ");
        }
    }
}
