using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using C__GC.Combats;

namespace C__GC.Entity
{
    public struct Stats(int ATK, int HP, int MANA)
    {
        public int atk = ATK;
        public int hp = HP;
        public int mana = MANA;
    }


    internal class Offense
    {
        public int dmg;

        public virtual void effect() { }
    }



    public class Character
    {
        int _hp;
        public int Hp { get => _hp; set => _hp = value; }
        int _mana;
        public int Mana { get => _mana; set => _mana = value; }
        private Stats _stats;
        public Stats Stats { get => _stats; set => _stats = value; }
        string _name;
        public string Name { get => _name; }
        List<Item> _items;
        public List<Item> Items { get => _items; set => _items = value; }
        List<Spell> _spells;
        public List<Spell> Spells { get => _spells; set => _spells = value; }
        public Action Suicide { get; set; }
        int _lvl;
        public int Lvl { get => _lvl; }

        public Character(string name, Stats stats)
        {
            _hp = stats.hp;
            _mana = stats.mana;
            Stats = stats;
            _name = name;
            _spells = [];
            _items = [];
        }


        public void TakeDmg(int amount)
        {
            _hp -= amount;

            if (_hp <= 0)
            {
                Suicide.Invoke();
            }
        }

        public void Healed(int amount)
        {
            if (_hp <= Stats.hp - amount)
            {
                _hp += amount;
            }
            else
            {
                _hp = Stats.hp;
            }
        }

        public virtual void Use(Character character)
        {
            Console.WriteLine($"You used {_name}!");

            character.TakeDmg(_stats.atk);
            character.ApplyAttackBonus(_stats.atk);
            character.RestoreMana(_mana);

        }

        public void attack(Character character)
        {
            character.TakeDmg(_stats.atk);
        }

        public void ApplyAttackBonus(int bonus)
        {
            // Apply the attack bonus to the character's attributes or stats
            _stats.atk += bonus;
        }

        public void RestoreMana(int amount)
        {
            _mana += amount;
        }

        public void Cast(Spell spell, Character target)
        {
            if (_spells.Contains(spell))
            {
                if (_mana >= spell._manaCost)
                {
                    spell.Cast(target);
                    _mana -= spell._manaCost;
                }
            }
        }

        public void LevelUp(Stats gain, Spell[] learn = null)
        {
            _lvl += 1;
            _stats.hp += gain.hp;
            _stats.mana += gain.mana;
            _stats.atk += gain.atk;
            _hp += gain.hp;
            _mana += gain.mana;

            foreach (Spell spell in learn)
            {
                _spells.Add(spell);
            }
        }
    }
}