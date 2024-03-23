using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__GC
{
    public struct Stats
    {
        public int atk;
        public int hp;
        public int mana;
    }


    internal class  Offense
    {
        public int dmg;

        public virtual void effect() { }
    }

    ref struct RefList
    {
        ref List<Character> _refList;
    }



    public class Character
    {
        int _hp;
        public int Hp { get => _hp; }

        int _mana;
        public int Mana { get => _mana; }

        int _atk;
        public int atk { get => _atk; }

        private Stats _stats;
        public Stats Stats { get => _stats; set => _stats = value; }
        string _name;
        Offense[] _offenses;
        Spell[] _spells;
        public Action Suicide { get; set; }

        public Character(string name, Stats stats) 
        {
            _hp = stats.hp;
            _mana = stats.mana;
            _atk = stats.atk;
            Stats = stats;
            _name = name;
            _offenses = [];
            _spells = [];
        }


        public void TakeDmg(int amount)
        {
            _hp -= amount;
            Console.WriteLine(_hp);

            if(_hp <= 0)
            {
                Suicide.Invoke();
            }
        }
        public void UseMana(int amount)
        {
            _mana -= amount;
            Console.WriteLine(_mana);
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
    }
}
