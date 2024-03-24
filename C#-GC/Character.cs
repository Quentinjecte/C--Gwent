using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    public struct Stats(int ATK, int HP, int MANA)
    {
        public int atk = ATK;
        public int hp = HP;
        public int mana = MANA;
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
        private Stats _stats;
        public Stats Stats { get => _stats; set => _stats = value; }
        string _name;
        public string Name { get => _name; }
        Offense[] _offenses;
        List<Spell> _spells;
        public List<Spell> Spells { get => _spells; set => _spells = value; }
        public Action Suicide { get; set; }

        public Character(string name, Stats stats) 
        {
            _hp = stats.hp;
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

        public void attack(Character character)
        {
            character.TakeDmg(_stats.atk);
        }
    }
}
