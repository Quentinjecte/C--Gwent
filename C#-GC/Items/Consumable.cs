using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__GC.Items
{
    internal class Consumable : Item
    {
        public Consumable(string  name, int value) : base(name, value, ItemType.Consumable)
        {
        }

        public override void Use()
        {
        }
    }
}
