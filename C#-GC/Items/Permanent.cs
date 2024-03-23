using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC.Items
{
    internal class Permanent : Item
    {
        public Permanent(string name, int value) : base(name, value, ItemType.Permanent)
        {
        }

        public override void Use()
        {
        }
    }
}
