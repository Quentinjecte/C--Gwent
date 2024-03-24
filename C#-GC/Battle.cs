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
        List<Protagonist> _protagonists;
        List<Enemy> _enemies;

        Character _currentTarget;
        Character _currentAuthor;

        public str_func[] _overlay;

        public Battle(List<Protagonist> protagonists, List<Enemy> enemies)
        {
            _overlay = new[] {// Update to do
                new str_func("      Attack      ", () => _currentAuthor.attack(_currentTarget), 0),
                new str_func("      Spell       "),
                new str_func("      Item        "),
            };

            _protagonists = protagonists;
            _enemies = enemies;
            foreach(Protagonist prota in _protagonists)
            {
                prota.Suicide += () => { _protagonists.Remove(prota); };
            }
            foreach(Enemy enemy in _enemies)
            {
                enemy.Suicide += () => { _enemies.Remove(enemy); };
            }
        }

        public bool start()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(_protagonists[0].Hp);
            Console.WriteLine(_enemies[0].Hp);
            Overlay menu = new Overlay();
            // assigner int Run au retour de cette fonction
            while (_protagonists.Count > 0 && _enemies.Count > 0)
            {
                foreach (Protagonist prota in _protagonists)
                {
                    _currentAuthor = prota;
                    _currentTarget = _enemies[0];
                    menu.InitPopUp(_overlay);
                    //ConsoleKeyInfo KeyPress = Console.ReadKey();
                    //switch (KeyPress.Key)
                    //{
                    //    case ConsoleKey.Z:
                    //        //_enemies[0].TakeDmg(_protagonists[0].Stats.atk);
                    //        //Status.Subscribe(() => Status.Burn(_protagonists[0]));
                    //        SpellCollection.testSpell.Cast(prota);
                            if(prota.Hp <= 0)
                            {
                                _protagonists.Remove(prota);
                            }

                    //        break;
                    //}
                }
                foreach (Enemy enemy in _enemies)
                {
                    // enemy plays
                    if (enemy.Hp <= 0)
                    {
                        _enemies.Remove(enemy);
                    }
                }

                Status.Tick();
            }
            return _protagonists.Count > 0;

        }

        private int kill(Enemy target)
        {
            _enemies.Remove(target);
            return _enemies.Count;
        }
        
        private int kill(Protagonist target)
        {
            _protagonists.Remove(target);
            return _protagonists.Count;
        }
    }
}
