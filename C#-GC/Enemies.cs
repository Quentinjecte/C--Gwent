namespace C__GC
{
    public class Enemy : Character
    {
        public Enemy(string name, Stats stats) : base(name, stats)
        {

        }

    }
    static public class EnemyFactory
    {
        static public Enemy basic() { return new Enemy("basic", new Stats(15, 100, 0)); }
        static public Enemy glassCanon() { return new Enemy("glassCanon", new Stats(50, 15, 0)); }
        static public Enemy caster() { return new Enemy("caster", new Stats(5, 70, 150)); }
    }
}