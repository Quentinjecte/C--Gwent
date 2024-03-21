using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    internal class Battle
    {
        Protagonist[] _protagonists;
        Character[] _enemies;
        string[] _BasicHUD = { "attack", "cast", "items" };
        string[] _HUD;
        int _HUDIndex;

        public Battle(Protagonist[] protagonists, Character[] enemies)
        {
            _protagonists = protagonists;
            _enemies = enemies;
            _HUD = _BasicHUD;
            _HUDIndex = 0;
        }

        public void start()
        {
            while (true)
            {
                foreach (Protagonist prota in _protagonists)
                {
                    ConsoleKeyInfo KeyPress = Console.ReadKey();
                    switch (KeyPress.Key)
                    {
                        case ConsoleKey.Z:
                            //_enemies[0].TakeDmg(_protagonists[0].Stats.atk);
                            //Status.Subscribe(() => Status.Burn(_protagonists[0]));
                            SpellCollection.testSpell.Cast(_protagonists[0]);

                            break;
                    }
                }
                foreach (Character character in _enemies)
                {
                    // enemy plays
                }

                Status.Tick();
            }

        }
    }
}
