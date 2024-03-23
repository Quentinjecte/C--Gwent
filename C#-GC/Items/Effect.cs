using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__GC.Items
{
    internal class Effect : Item
    {
        public Effect(string  name, int value) : base(name, value, ItemType.Effect)
        {
        }

        public override void Use()
        {
            Console.WriteLine($"Tu as utilisé {_name} ! ");
        }
    }
}
