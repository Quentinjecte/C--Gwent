using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
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
        DisplayElement _hud;

        Overlay _menu;

        public Battle(List<Protagonist> protagonists, List<Enemy> enemies)
        {
            Overlay _menu = new Overlay();
            _overlay = new[] {
                // Attack option
                new str_func("Attack          ", () => { 
                    // Select target
                    str_func[] nextOverlay = new str_func[_enemies.Count];
                    for(int i = 0; i < _enemies.Count; i++)
                    {
                        int iCopy = i;
                        nextOverlay[i] = new str_func(i.ToString(), () =>
                        {
                            _currentAuthor.attack(_enemies[iCopy]);
                        }, 0);
                    }
                    _menu.InitPopUp(nextOverlay, 10, 25); 
                    },0),

                // Spell option
                new str_func("Spell           ", () => {
                    // Select spell
                    str_func[] nextOverlay = new str_func[_currentAuthor.Spells.Count];
                    for(int i = 0; i < _currentAuthor.Spells.Count; i++)
                    {
                        int iCopy = i;
                        nextOverlay[i] = new str_func(_currentAuthor.Spells[iCopy]._name, () =>
                        {
                            // Select target
                            str_func[] nextOverlay = new str_func[_enemies.Count];
                            for(int j = 0; j < _enemies.Count; j++)
                            {
                                int jCopy = j;
                                nextOverlay[j] = new str_func(j.ToString(), () =>
                                {
                                    _currentAuthor.Cast(_currentAuthor.Spells[iCopy], _enemies[jCopy]);
                                }, 0);
                            }
                        _menu.InitPopUp(nextOverlay, 15, 25);
                        }, 0);
                    }
                    _menu.InitPopUp(nextOverlay, 10, 25);
                }, 0),

                new str_func("Item            "),
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
            
            // assigner int Run au retour de cette fonction
            _hud = new DisplayElement("", 30, 0, 0);
            UpdateHUD();
            DisplaySystem.Subscribe(_hud);
            DisplaySystem.Update();

            Overlay _menu = new Overlay();

            while (_protagonists.Count > 0 && _enemies.Count > 0)
            {
                foreach (Protagonist prota in _protagonists)
                {
                    _currentAuthor = prota;
                    _currentTarget = _enemies[0];
                    _menu.InitPopUp(_overlay, 3, 25, true);
                    //        Status.Subscribe(() => Status.Burn(_protagonists[0]));
                    //        SpellCollection.testSpell.Cast(prota);
                    if(prota.Hp <= 0)
                    {
                        prota.Suicide();
                    }
                }
                foreach (Enemy enemy in _enemies)
                {
                    enemy.RandomAction(ref _protagonists);
                    if (enemy.Hp <= 0)
                    {
                        enemy.Suicide();
                    }
                }

                Status.Tick();
                UpdateHUD();

            }
            DisplaySystem.Unsubscribe();
            DisplaySystem.Update();
            return _protagonists.Count > 0;

        }

        private void UpdateHUD()
        {
            DisplayElement oldHUD = _hud;
            _hud.content = "|----------------------------|";
                foreach (Protagonist prota in _protagonists)
            {
                _hud.content += "| protaHP:" + _protagonists[0].Hp + "                |"; ;
            }
            foreach(Enemy enemy in _enemies)
            {
                _hud.content += "| enemyHP:" + enemy.Hp + "                 |";
            }

            _hud.content += "|                            |" +
                "|----------------------------|";
            DisplaySystem.ReplaceByValue(oldHUD, _hud);
            DisplaySystem.Update();
        }

    }
}
