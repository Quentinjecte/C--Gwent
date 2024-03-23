using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__GC.Items
{
    internal class Heal : Item
    {
        public int _healingAmount { get; set; }

        public Heal(string name, int value, int healingAmount) : base(name, value, ItemType.Heal)
        {
            _healingAmount = healingAmount;
        }

        public override void Use(Character character)
        {
            Console.WriteLine($"Tu as utilisé {_name} ! ");
        }
    }
}
