using System.Runtime.Intrinsics.Arm;

namespace C__GC.Combats
{
    public class Enemy : Character
    {
        public Enemy(string name, Stats stats) : base(name, stats)
        {

        }

        public void RandomAction(ref List<Protagonist> targets)
        {
            Random rdm = new();
            Protagonist target = targets[rdm.Next(0, targets.Count)];
            switch (rdm.Next(0, 1))
            {
                case 0:
                    attack(target);
                    break;
            }
        }

    }
    static public class EnemyFactory
    {
        static public Enemy basic() { return new Enemy("basic", new Stats(15, 100, 0)); }
        static public Enemy glassCanon() { return new Enemy("glassCanon", new Stats(50, 15, 0)); }
        static public Enemy caster() { return new Enemy("caster", new Stats(5, 70, 150)); }
    }
}