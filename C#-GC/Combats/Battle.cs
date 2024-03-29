using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using C__GC.Combats;
using C__GC.DataString;
using C__GC.Entity;
using C__GC.Hub;
using C__GC.Player;

namespace C__GC
{
    internal class Battle
    {
        List<Protagonist> _protagonists;
        List<DisplayElement> _protaSprites;
        List<Enemy> _enemies;
        List<DisplayElement> _enemiesSprites;
        //private List<DisplayElement> _healthBars;

        Character _currentTarget;
        Character _currentAuthor;

        public str_func[] _overlay;
        DisplayElement _hud;


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
                    _menu.InitPopUp(nextOverlay, 10, 15);
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
                        _menu.InitPopUp(nextOverlay, 15, 15);
                        }, 0);
                    }
                    _menu.InitPopUp(nextOverlay, 10, 15);
                }, 0),

                new str_func("Item           ", () => {
                    // Select Item
                    str_func[] nextOverlay = new str_func[_currentAuthor.Items.Count];
                    for(int i = 0; i < _currentAuthor.Items.Count; i++)
                    {
                        int iCopy = i;
                        nextOverlay[i] = new str_func(_currentAuthor.Items[iCopy]._name, () =>
                        {
                             //_currentAuthor.Use(_currentAuthor.Items[iCopy]);
                        _menu.InitPopUp(nextOverlay, 15, 25);
                        }, 0);
                    }
                    _menu.InitPopUp(nextOverlay, 10, 25);
                }, 0),
            };

            _protagonists = protagonists;
            _enemies = enemies;
            _protaSprites = new();
            _enemiesSprites = new();
            _healthBars = new List<DisplayElement>();

            foreach (Protagonist prota in _protagonists)
            {
                prota.Suicide += () => { _protagonists.Remove(prota); };
            }
            foreach (Enemy enemy in _enemies)
            {
                enemy.Suicide += () => { _enemies.Remove(enemy); };
            }
        }
        public bool start()
        {

            // assigner int Run au retour de cette fonction
            InitHud();

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
                    _menu.InitPopUp(_overlay, 3, 15, true);
                    //        Status.Subscribe(() => Status.Burn(_protagonists[0]));
                    //        SpellCollection.testSpell.Cast(prota);
                    if (prota.Hp <= 0)
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


        private void DeleteHUD()
        {
            foreach (DisplayElement sprite in _protaSprites)
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

            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemiesSprites.Add(new DisplayElement(ResourceAllocator.GetFrontMap("enemies.txt"), -1, 160 + 30 * i, 2));
                DisplaySystem.Subscribe(_enemiesSprites[i]);
            }
        }


    }
}
