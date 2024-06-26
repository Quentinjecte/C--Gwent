﻿using System.Drawing;
using System.Runtime.CompilerServices;
using C__GC.Combats;
using C__GC.DataString;
using C__GC.Entity;
using C__GC.Hub;

namespace C__GC.Player
{

    struct Inventory
    {
        int golds;
        int soulTokens;
    }


    public class Player
    {
        /*
        ------------------------------------------------------
        |             Initialize Varialbe Player.cs          |                     
        ------------------------------------------------------
        */
        private string _map;
        private int _size;
        public int playerX = 5;
        public int playerY = 5;
        DisplayElement _playerRender;
        MapManager _mapManager;

        List<Protagonist> _team;
        List<Enemy> _enemies;
        public List<Protagonist> Team { get => _team; }
        public List<Enemy> Enemies { get => _enemies; }

        Random rdm = new();

        /*
        ------------------------------------------------------
        |             Initialize Function Player.cs          |                     
        ------------------------------------------------------
        */
        public Player()
        {
        }
        public void InitPlayer(string map, int size, MapManager mapManager)
        {
            _map = map;
            _size = size;
            _playerRender = new DisplayElement(ResourceAllocator.GetFrontMap("character.txt"), -1, playerX, playerY);
            _team = new List<Protagonist>();
            DisplaySystem.Subscribe(_playerRender);

            Stats stats = new Stats();
            stats.mana = 200;
            stats.hp = 100;
            stats.atk = 100;

            Protagonist prota = new Protagonist("jenti", stats);
            prota.Spells.Add(SpellCollection.minorHealSpell);
            prota.Spells.Add(SpellCollection.curativPrayerSpell);
            Recruite(prota);
            _mapManager = mapManager;
        }
        //saveS
        public void Input(int x, int y)
        {
            Overlay overlay = new();
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Z:
                        (x, y) = (0, -1);
                        break;
                    case ConsoleKey.S:
                        (x, y) = (0, 1);
                        break;
                    case ConsoleKey.Q:
                        (x, y) = (-1, 0);
                        break;
                    case ConsoleKey.D:
                        (x, y) = (1, 0);
                        break;
                    case ConsoleKey.P:
                        overlay.InitPopUp(overlay._OverlayOptions, 20, 25);
                        if (keyInfo.Key == ConsoleKey.P)
                        {
                            Console.ReadKey(true);
                        }
                        break;
                    default:
                        continue;
                }

                int newX = playerX + x;
                int newY = playerY + y;

                if (IsObstacle(newX, newY) == false)
                {
                    Move(x, y);
                    if (IsGrass(newX, newY))
                    {
                        if (rdm.Next(0, 10) == 0)
                        {
                            Difficulty difficulty = new();
                            difficulty.EnemyCount();
                            Battle battle = new Battle(_team, Difficulty.Enemy);

                            if (battle.start() == false)
                            {
                                return;
                            }
                        }
                    }
                    else if (IsTavern(newX, newY))
                    {
                        Stats stats = new Stats();
                        stats.mana = 200;
                        stats.hp = 100;
                        stats.atk = 100;

                        Protagonist prota = new Protagonist("jenti", stats);
                        prota.Spells.Add(SpellCollection.toxicVaporSpell);
                        prota.Spells.Add(SpellCollection.chargeSpell);
                        Recruite(prota);
                    }
                    if (IsTransition(newX, newY))
                    {
                        _map = _mapManager.ChangeMap("map2"); // Call a method to change the map
                    }
                }

            } while (true);
        }
        private void Move(int x, int y)
        {
            DisplayElement oldRender = _playerRender;
            playerX += x;
            playerY += y;
            _playerRender.xOffset = playerX;
            _playerRender.yOffset = playerY;
            DisplaySystem.ReplaceByValue(oldRender, _playerRender);
            DisplaySystem.Update();

        }
        private bool IsObstacle(int x, int y)
        {
            return _map[y * _size + x] == '#';
        }
        private bool IsGrass(int x, int y)
        {
            return _map[y * _size + x] == '@';
        }
        private bool IsTavern(int x, int y)
        {
            return _map[y * _size + x] == '&';
        }
        public void Recruite(Protagonist prota)
        {
            _team.Add(prota);
            prota.Suicide += () => { _team.Remove(prota); };
        }
        private bool IsTransition(int x, int y)
        {
            return _map[y * _size + x] == '*';
        }
        public void SetPlayerPosition(int x, int y)
        {
            DisplayElement oldRender = _playerRender;
            playerX = x;
            playerY = y;
            DisplaySystem.ReplaceByValue(oldRender, _playerRender);
            DisplaySystem.Update();
        }
    }
}
