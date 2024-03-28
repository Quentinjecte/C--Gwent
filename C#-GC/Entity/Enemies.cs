using System.Runtime.Intrinsics.Arm;
using C__GC.Entity;
using C__GC.Player;

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
        static private int rdmStuff(int min, int max) { Random rdm = new Random(); return rdm.Next(min, max); }
        // static public Enemy basic() { return new Enemy("basic", new Stats(15, 100, 0)); }
        // static public Enemy glassCanon() { return new Enemy("glassCanon", new Stats(50, 15, 0)); }
        // static public Enemy caster() { return new Enemy("caster", new Stats(5, 70, 150)); }
        static public Enemy carionEaterEnemy() { return new Enemy("Carion Eater", new Stats(rdmStuff(1, 5), 12, 5)); }
        static public Enemy flayerEnemy() { return new Enemy("Flayer", new Stats(rdmStuff(2, 5), 15, 3)); }
        static public Enemy houndEnemy() { return new Enemy("Hound", new Stats(rdmStuff(1, 6), 12, 3)); }
        static public Enemy clumpsEnemy() { return new Enemy("Clumps", new Stats(rdmStuff(2, 6), 16, 6)); }
        static public Enemy gnasherEnemy() { return new Enemy("Gnasher", new Stats(rdmStuff(2, 5), 20, 2)); }
        static public Enemy cherubEnemy() { return new Enemy("Cherub", new Stats(rdmStuff(1, 2), 10, 8)); }
        static public Enemy facelingEnemy() { return new Enemy("Faceling", new Stats(rdmStuff(2, 5), 15, 4)); }
        static public Enemy sculptureEnemy() { return new Enemy("Sculpture", new Stats(rdmStuff(3, 4), 18, 8)); }
    }
}