using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC.Combats
{
    internal class Difficulty
    {
        List<int> Entity = new List<int>();
        public static List<Enemy> Enemy = new List<Enemy>();
        Random rdm = new();
        public static bool Easy, 
            Medium,
            Hard;

        public void EnemyCount() 
        {
            if (true == Easy)
            {
                for (int i = 0; i < 1; i++)
                {
                    Entity.Add(rdm.Next(0, 2));
                }
            }
            else if (true == Medium)
            {
                for (int i = 0; i < rdm.Next(1, 2); i++)
                {
                    Entity.Add(rdm.Next(0, 2));
                }
            }
            else if (true == Hard)
            {
                for (int i = 0; i < rdm.Next(1, 3); i++)
                {
                    Entity.Add(rdm.Next(1, 2));
                }
            }
            else Console.WriteLine("False");

            foreach (int i in Entity)
            {
                if (i == 0)
                {
                    Enemy.Add(EnemyFactory.basic());
                }
                if (i == 1)
                {
                    Enemy.Add(EnemyFactory.glassCanon());
                }
                if (i == 2)
                {
                    Enemy.Add(EnemyFactory.caster());
                }
            }

        }
    }
}
