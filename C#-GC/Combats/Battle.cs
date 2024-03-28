using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using C__GC.Entity;
using C__GC.Hub;

namespace C__GC
{
    internal class Battle
    {
        List<Protagonist> _protagonists;
        List<DisplayElement> _protaSprites;
        List<Enemy> _enemies;
        List<DisplayElement> _enemiesSprites;

        Character _currentTarget;
        Character _currentAuthor;

        public str_func[] _overlay;
        DisplayElement _hud;

        Overlay _menu;

        public Battle(List<Protagonist> protagonists, List<Enemy> enemies)
        {
            Overlay _menu = new Overlay();
            Overlay.InFight = true;
            _overlay = new[] {
                // Attack option
                new str_func("  Attack          ", () => { 
                    // Select target
                    str_func[] nextOverlay = new str_func[_enemies.Count];
                    for(int i = 0; i < _enemies.Count; i++)
                    {
                        int Icopy = i;
                        nextOverlay[i] = new str_func(i.ToString(), () =>
                        {
                            _currentAuthor.attack(_enemies[Icopy]);
                        }, 0);
                    }
<<<<<<< HEAD:C#-GC/Battle.cs
                    _menu.InitPopUp(nextOverlay, 10, 15); 
=======
                    _menu.InitPopUp(nextOverlay, 0, 0); 
>>>>>>> SAVEcOMMIT:C#-GC/Combats/Battle.cs
                    },0),

                // Spell option
                new str_func("  Spell           ", () => {
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
<<<<<<< HEAD:C#-GC/Battle.cs
                        _menu.InitPopUp(nextOverlay, 15, 15);
                        }, 0);
                    }
                    _menu.InitPopUp(nextOverlay, 10, 15);
=======
                        _menu.InitPopUp(nextOverlay, 0, 0);
                        }, 0);
                    }
                    _menu.InitPopUp(nextOverlay, 0, 0);
>>>>>>> SAVEcOMMIT:C#-GC/Combats/Battle.cs
                }, 0),

                new str_func("  Item            "),
            };

            _protagonists = protagonists;
            _enemies = enemies;
            _protaSprites = new();
            _enemiesSprites = new();
            foreach (Protagonist prota in _protagonists)
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
            
            // assigner int Run au retour de cette fonction
<<<<<<< HEAD:C#-GC/Battle.cs
            InitHud();
=======
            _hud = new DisplayElement(" ", 30, 0, 0);
            UpdateHUD();
            DisplaySystem.Subscribe(_hud);
            DisplaySystem.Update();
>>>>>>> SAVEcOMMIT:C#-GC/Combats/Battle.cs

            Overlay _menu = new Overlay();
            DisplayElement map = DisplaySystem.GetById(0);
            DisplaySystem.ReplaceByIndex(0, new DisplayElement("", 1, 0, 0));
            DisplaySystem.Update(true);

            while (_protagonists.Count > 0 && _enemies.Count > 0)
            {
                foreach (Protagonist prota in _protagonists)
                {
                    _currentAuthor = prota;
                    _currentTarget = _enemies[0];
<<<<<<< HEAD:C#-GC/Battle.cs
                    _menu.InitPopUp(_overlay, 3, 15, true);
=======
                    _menu.InitPopUp(_overlay, 3, 0, true);
>>>>>>> SAVEcOMMIT:C#-GC/Combats/Battle.cs
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

            }
            DeleteHUD();


            DisplaySystem.ReplaceByIndex(0, map);
            //DisplaySystem.Update(true);
            return _protagonists.Count > 0;

        }
<<<<<<< HEAD:C#-GC/Battle.cs

        private void DeleteHUD()
        {
            foreach(DisplayElement sprite in _protaSprites)
=======
        private void UpdateHUD()
        {
            Console.Clear();
            DisplayElement oldHUD = _hud;
            _hud.content = "|----------------------------|";
                foreach (Protagonist prota in _protagonists)
>>>>>>> SAVEcOMMIT:C#-GC/Combats/Battle.cs
            {
                DisplaySystem.Unsubscribe(sprite);
            }
            //foreach(Enemy enemy in _enemies)
            //{
            //    _hud.content += "| enemyHP:" + enemy.Hp + "                 |";
            //}
        }
        private void InitHud()
        {
            for (int i = 0; i < _protagonists.Count; i++)
            {
                _protaSprites.Add(new DisplayElement(ResourceAllocator.GetFrontMap("fighter.txt"), -1, 25 + 30 * i, 2));
                DisplaySystem.Subscribe(_protaSprites[i]);
            }
        }

    }
}
