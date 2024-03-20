/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    internal class Battle
    {
        Protagonist[] m_protagonists;
        Character[] m_enemies;
        string[] m_BasicHUD = { "attack", "cast", "items" };
        string[] m_HUD;
        int m_HUDIndex;

        public Battle(Protagonist[] protagonists, Character[] enemies)
        {
            m_protagonists = protagonists;
            m_enemies = enemies;
            m_HUD = m_BasicHUD;
            m_HUDIndex = 0;
        }

        public void start()
        {
            bool run = true;
            while(run)
            {
                foreach(Protagonist currentProta in m_protagonists) 
                {
                    SwapIndex();
                    play(currentProta);
                }
                foreach(Character currentEnemy in m_enemies) 
                {
                    play(currentEnemy);
                }
            }
        }

        private void OverlayOption()
        {
            for (int i = 0; i < m_HUD.Length; i++)
            {
                string ActChoise;
                string CurrentOption = m_HUD[i];

                if (i == m_HUDIndex)
                {
                    ActChoise = "->";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    ActChoise = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{ActChoise}  {CurrentOption}");
            }
            Console.ResetColor();
        }

       

        public void SwapIndex()
        {
            ConsoleKey KeyPress;

            do
            {
                Console.Clear();
                OverlayOption();

                ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
                KeyPress = KeyInfo.Key;

                if (KeyPress == ConsoleKey.UpArrow)
                {
                    m_HUDIndex--;
                    if (m_HUDIndex == -1)
                    {
                        m_HUDIndex = m_HUD.Length - 1;
                    }
                }
                else if (KeyPress == ConsoleKey.DownArrow)
                {
                    m_HUDIndex++;
                    if (m_HUDIndex == m_HUD.Length)
                    {
                        m_HUDIndex = 0;
                    }
                }
            }
            while (KeyPress != ConsoleKey.Spacebar);
        }

        private void play(Protagonist prota)
        {
            switch (m_HUDIndex)
            {
                case 0:
                    //attack
                    break;

                case 1:
                    Array.Clear(m_HUD, 0, m_HUD.Length);
                    foreach(Spell spell in prota.spells)
                    {
                        m_HUD.Append(spell.name);
                    }
                    break;

                case 2:
                    //open inventory
                    break;
            }
        }
        private void play(Character enemy)
        {

        }
    }
}
*/